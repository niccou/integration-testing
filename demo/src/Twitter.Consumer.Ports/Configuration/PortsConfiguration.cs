using Microsoft.Extensions.DependencyInjection;
using Twitter.Consumer.Core.ReadingTweets;
using Twitter.Consumer.Ports.ReadingTweets;

namespace Twitter.Consumer.Ports.Configuration
{
    public static class PortsConfiguration
    {
        public static IServiceCollection AddPortsConfiguration(this IServiceCollection services)
            => services
                .AddTransient<ISearchTweet, SearchTweetFromTwitter>();
    }
}
