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

namespace IVAXOR.PatreonNET.Services
{
    public class PatreonAPIv1Query<TResponse, TAttributes, TRelationships>
        where TResponse : IPatreonResponse<TAttributes, TRelationships>
        where TAttributes : IPatreonAttributes
        where TRelationships : IPatreonRelationships
    {
        protected readonly string Url;
        protected readonly HttpClient HttpClient;
        protected readonly IPatreonTokenManager PatreonTokenManager;

        protected internal HashSet<string> IncludeFields { get; set; } = new HashSet<string>();

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
            IncludeFields.Add(propertyName);

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
            using var request = new HttpRequestMessage(HttpMethod.Get, Url);
            request.Headers.Add("Authorization", $"Bearer {PatreonTokenManager.AccessToken}");

            using var response = await HttpClient.SendAsync(request, cancellationToken);
            if (!response.IsSuccessStatusCode) throw new HttpRequestException();

            using var responseStream = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<TResponse>(responseStream, Json.SerializerOptions, cancellationToken);
        }
    }
}
