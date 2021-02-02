using System;
using System.Threading.Tasks;

namespace Twitter.Consumer.Core.ReadingTweets
{
    internal class GiveTweet : IGiveTweet
    {
        private ISearchTweet SearchTweet { get; }

        public GiveTweet(ISearchTweet searchTweet)
        {
            SearchTweet = searchTweet;
        }

        public Task<Tweet> SearchByIdAsync(string id) => SearchTweet.ByIdAsync(id);
    }
}
