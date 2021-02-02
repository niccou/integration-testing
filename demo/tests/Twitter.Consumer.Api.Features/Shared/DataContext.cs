using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace Twitter.Consumer.Api.Features.Shared
{
    public class DataContext : IClassFixture<ApiServer>
    {
        private ApiServer Server
        {
            get => Get<ApiServer>();
            set => Set(value);
        }

        protected void SetupRouteResponse(
            HttpMethod method,
            string route,
            HttpResponseMessage response) =>
            Server.SetupRouteResponse(method, route, response);

        public void SetupRouteResponse(
            HttpMethod method,
            string route,
            Func<HttpRequestMessage, Task<HttpResponseMessage>> requestHandler) =>
            Server.SetupRouteResponse(method, route, requestHandler);

        public void SetupRouteResponse(
            HttpMethod method,
            string route,
            HttpResponseMessage response,
            params KeyValuePair<string, string>[] query) =>
            Server.SetupRouteResponse(method, route, response, query);

        public void SetupRouteResponse(
            HttpMethod method,
            string route,
            Func<HttpRequestMessage, Task<HttpResponseMessage>> requestHandler,
            params KeyValuePair<string, string>[] query) =>
            Server.SetupRouteResponse(method, route, requestHandler, query);

        protected HttpClient Client => Server.Client;

        private ScenarioContext Context { get; }

        protected void Set<T>(T value, [CallerMemberName] string key = null)
            => Context[key] = value;

        protected T Get<T>([CallerMemberName] string key = null)
            => Context.TryGetValue<T>(key, out T value)
                ? value
                : default;

        protected void Pending() => Context.Pending();

        protected DataContext(ScenarioContext context, ApiServer server)
            => (Context, Server) = (context, server);
    }
}