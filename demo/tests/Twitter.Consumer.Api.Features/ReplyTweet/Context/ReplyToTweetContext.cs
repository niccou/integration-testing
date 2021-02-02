using System.Collections.Generic;
using System.Net.Http;
using TechTalk.SpecFlow;
using Twitter.Consumer.Api.Features.Shared;
using Twitter.Consumer.Ports.Models;

namespace Twitter.Consumer.Api.Features.ReplyTweet.Context
{
    public class ReplyToTweetContext : DataContext
    {
        protected ICollection<Tweet> TweetsOnTwitter
        {
            get => Get<ICollection<Tweet>>();
            set => Set(value);
        }

        protected string Route
        {
            get => Get<string>();
            set => Set(value);
        }

        protected HttpResponseMessage Response
        {
            get => Get<HttpResponseMessage>();
            set => Set(value);
        }

        protected Models.Tweet TweetReceived
        {
            get => Get<Models.Tweet>();
            set => Set(value);
        }

        
        protected ReplyToTweetContext(ScenarioContext context, ApiServer server) : base(context, server)
        {
            TweetsOnTwitter = new List<Tweet>();
        }
    }
}
