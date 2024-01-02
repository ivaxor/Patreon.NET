using IVAXOR.PatreonNET.Constants;
using IVAXOR.PatreonNET.Models.Response.Interfaces;
using IVAXOR.PatreonNET.Services.TokenManagers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading;
using IVAXOR.PatreonNET.Services.API.Extensions;
using IVAXOR.PatreonNET.Exceptions;

namespace IVAXOR.PatreonNET.Services.API
{
    public class PatreonAPIv2Query<TResponse, TAttributes, TRelationships>
        where TResponse : IPatreonResponse<TAttributes, TRelationships>
        where TAttributes : IPatreonAttributes
        where TRelationships : IPatreonRelationships
    {
        public readonly string Url;

        protected readonly HttpClient HttpClient;
        protected readonly IPatreonTokenManager PatreonTokenManager;

        protected internal HashSet<string> TopLevelIncludes { get; set; } = new HashSet<string>();
        protected internal HashSet<string> IncludeFields { get; set; } = new HashSet<string>();

        public PatreonAPIv2Query(
            string url,
            HttpClient httpClient,
            IPatreonTokenManager patreonTokenManager)
        {
            Url = url;
            HttpClient = httpClient;
            PatreonTokenManager = patreonTokenManager;
        }

        public PatreonAPIv2Query<TResponse, TAttributes, TRelationships> Include(string topLevelInclude)
        {
            TopLevelIncludes.Add(topLevelInclude);
            return this;
        }

        public PatreonAPIv2Query<TResponse, TAttributes, TRelationships> IncludeAllFields()
        {
            typeof(TAttributes).GetProperties()
                .Select(_ => _.Name)
                .ToList()
                .ForEach(_ => IncludeFields.Add(_));

            return this;
        }

        public PatreonAPIv2Query<TResponse, TAttributes, TRelationships> IncludeField(string propertyName)
        {
            if (!typeof(TAttributes).GetProperties().Any(_ => _.Name == propertyName)) throw new ArgumentException("Invalid value", nameof(propertyName));
            IncludeFields.Add(propertyName);

            return this;
        }

        public PatreonAPIv2Query<TResponse, TAttributes, TRelationships> IncludeField(Expression<Func<TAttributes, object>> selector)
        {
            var propertyType = (PropertyInfo)((MemberExpression)selector.Body).Member;
            return IncludeField(propertyType.Name);
        }

        public async ValueTask<TResponse> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            var url = Url;

            var includes = this.GetTopLevelIncludeQuery();
            var fields = this.GetIncludeFieldsQuery();


            if (includes != null && fields != null) url = $"{Url}?{includes}&{fields}";
            else
            {
                if (includes != null) url = $"{Url}?{includes}";
                if (fields != null) url = $"{Url}?{fields}";
            }

            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Authorization", $"Bearer {PatreonTokenManager.AccessToken}");

            using var response = await HttpClient.SendAsync(request, cancellationToken);
            if (!response.IsSuccessStatusCode) throw new PatreonAPIException(response);

            var rawJson = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponse>(rawJson, Json.SerializerOptions);
        }
    }
}
