using FluentAssertions;
using FluentAssertions.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Twitter.Consumer.Api.Features.Shared;
using Twitter.Consumer.Api.Features.Tweets.Context;
using Twitter.Consumer.Ports.Models;
using Twitter.Consumer.Ports.Shared;
using static System.Net.HttpStatusCode;

namespace Twitter.Consumer.Api.Features.Tweets.Bindings
{
    [Binding]
    public class BatchTweetSteps : BatchTweetContext
    {
        public BatchTweetSteps(ScenarioContext context, ApiServer server) : base(context, server) { }

        [Given("Je peux interroger l'api de Twitter")]
        public void GivenJePeuxInterrogerLApiDeTwitter() { }

        [Given("Je peux accéder à une liste de tweets")]
        public void GivenJePeuxAccederAUneListeDeTweets(Table table)
            => TweetsOnTwitter = table.Rows
            .Select(_ => new Tweet
            {
                Id = _["Id"],
                ConversationId = _["Conversation"],
                Text = _["Text"],
                AuthorId = _["Author"],
                CreatedAt = DateTime.Parse(_["Created"])
            }).ToList();

        [Given("Je veux consulter un simple tweet")]
        public void GivenJeVeuxConsulterUnSimpleTweet()
        {
            Route = "/api/v1/tweet/";
        }

        [When("Je demande le tweet (.*)")]
        public async Task WhenJeDemandeLeTweet(string tweetId)
        {
            SetupRouteResponse(HttpMethod.Get, $"/2/tweets/{tweetId}", new HttpResponseMessage(OK)
            {
                Content = new StringContent(JsonSerializer.Serialize(TweetsOnTwitter.SingleOrDefault(_ => _.Id == tweetId)))
            });

            Response = await Client.GetAsync(new Uri($"{Route}{tweetId}", UriKind.Relative)).ConfigureAwait(false);
        }

        [Then("Je recois une réponse")]
        public void ThenJeRecoisUneReponse() => Response.StatusCode.Should().Be(OK);

        [Then("Je peux consulter le message du tweet : (.*)")]
        public async Task ThenJePeuxConsulterLeMessageDuTweet(string expectedMessage)
        {
            var content = await Response.Content.ReadAsStringAsync().ConfigureAwait(false);

            TweetReceived = content.Deserialize<Models.Tweet>();

            TweetReceived.Message.Should().Be(expectedMessage);
        }

        [Then("Je recois une réponse non trouvé")]
        public void ThenJeRecoisUneReponseNonTrouve() => Response.StatusCode.Should().Be(NotFound);
    }
}
