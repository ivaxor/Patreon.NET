using System.Linq.Expressions;
using System.Reflection;
using System;
using System.Collections.Generic;
using IVAXOR.PatreonNET.Models.Response.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using IVAXOR.PatreonNET.Services.TokenManagers.Interfaces;
using System.Net.Http;
using IVAXOR.PatreonNET.Constants;
using System.Text.Json;
using IVAXOR.PatreonNET.Services.API.Extensions;
using IVAXOR.PatreonNET.Exceptions;

namespace IVAXOR.PatreonNET.Services.API
{
    public class PatreonAPIv1Query<TResponse, TAttributes, TRelationships>
        where TResponse : IPatreonResponse<TAttributes, TRelationships>
        where TAttributes : IPatreonAttributes
        where TRelationships : IPatreonRelationships
    {
        public readonly string Url;

        protected readonly HttpClient HttpClient;
        protected readonly IPatreonTokenManager PatreonTokenManager;

        protected internal HashSet<string> IncludeAdditionalFields { get; set; } = new HashSet<string>();

        public PatreonAPIv1Query(
            string url,
            HttpClient httpClient,
            IPatreonTokenManager patreonTokenManager)
        {
            Url = url;
            HttpClient = httpClient;
            PatreonTokenManager = patreonTokenManager;
        }

        public PatreonAPIv1Query<TResponse, TAttributes, TRelationships> IncludeAdditionalField(string propertyName)
        {
            if (!typeof(TAttributes).GetProperties().Any(_ => _.Name == propertyName)) throw new ArgumentException("Invalid value", nameof(propertyName));
            IncludeAdditionalFields.Add(propertyName);

            return this;
        }

        public PatreonAPIv1Query<TResponse, TAttributes, TRelationships> IncludeAdditionalField(Expression<Func<TAttributes, object>> selector)
        {
            var propertyType = (PropertyInfo)((MemberExpression)selector.Body).Member;
            IncludeAdditionalField(propertyType.Name);

            return this;
        }

        public async ValueTask<TResponse> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            var url = Url;

            var fields = this.GetIncludeAdditionalFieldsQuery();
            if (fields == null) url = $"{Url}?{fields}";

            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Authorization", $"Bearer {PatreonTokenManager.AccessToken}");

            using var response = await HttpClient.SendAsync(request, cancellationToken);
            if (!response.IsSuccessStatusCode) throw new PatreonAPIException(response);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<TResponse>(responseStream, Json.SerializerOptions, cancellationToken);
        }
    }
}
