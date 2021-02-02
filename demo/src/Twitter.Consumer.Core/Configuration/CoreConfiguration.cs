using Microsoft.Extensions.DependencyInjection;
using Twitter.Consumer.Core.ReadingTweets;

namespace Twitter.Consumer.Core.Configuration
{
    public static class CoreConfiguration
    {
        public static IServiceCollection AddCoreConfiguration(this IServiceCollection services)
            => services
                .AddTransient<IGiveTweet, GiveTweet>();
    }
}
