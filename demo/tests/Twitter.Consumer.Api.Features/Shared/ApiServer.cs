using Bogus;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using RichardSzalay.MockHttp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Twitter.Consumer.Api.Features.Shared
{
    public class ApiServer : IClassFixture<WebApplicationFactory<Startup>>
    {
        private static Faker Faker => new Faker();

        private Mock<IHttpClientFactory> ClientFactory { get; } = new Mock<IHttpClientFactory>();

        private WebApplicationFactory<Startup> Factory { get; }

        private MockHttpMessageHandler MessageHandler { get; } = new MockHttpMessageHandler();

        public HttpClient Client { get; }

        public ApiServer(WebApplicationFactory<Startup> factory)
        {
            ClientFactory
                .Setup(_ => _.CreateClient(It.IsAny<string>()))
                .Returns(CreateWebServiceClient);

            Client = factory.WithWebHostBuilder(builder =>
                builder.ConfigureTestServices(services =>
                    services.RemoveAll<IHttpClientFactory>().AddTransient(_ => ClientFactory.Object)
            )).CreateClient();

            Client.BaseAddress = new Uri("http://api.com/", UriKind.Absolute);
        }

        public void SetupRouteResponse(
            HttpMethod method,
            string route,
            HttpResponseMessage response) =>
            MessageHandler
                .When(method, route)
                .Respond(() => Task.FromResult(response));

        public void SetupRouteResponse(
            HttpMethod method,
            string route,
            Func<HttpRequestMessage, Task<HttpResponseMessage>> requestHandler) =>
            MessageHandler
                .When(method, route)
                .Respond(requestHandler);

        public void SetupRouteResponse(
            HttpMethod method,
            string route,
            HttpResponseMessage response,
            params KeyValuePair<string, string>[] query) =>
            MessageHandler
                .When(method, route)
                .WithQueryString(query)
                .Respond(() => Task.FromResult(response));

        public void SetupRouteResponse(
            HttpMethod method,
            string route,
            Func<HttpRequestMessage, Task<HttpResponseMessage>> requestHandler,
            params KeyValuePair<string, string>[] query) =>
            MessageHandler
                .When(method, route)
                .WithQueryString(query)
                .Respond(requestHandler);

        private HttpClient CreateWebServiceClient()
        {
            var client = MessageHandler.ToHttpClient();
            client.BaseAddress = new Uri(Faker.Internet.Url());
            return client;
        }
    }
}