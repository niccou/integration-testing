using AutoMapper;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Twitter.Consumer.Core.ReadingTweets;
using Twitter.Consumer.Ports.Shared;

namespace Twitter.Consumer.Ports.ReadingTweets
{
    internal class SearchTweetFromTwitter : ISearchTweet
    {
        private IHttpClientFactory Factory { get; }
        private IMapper Mapper { get; }

        public SearchTweetFromTwitter(IHttpClientFactory factory, IMapper mapper)
        {
            Factory = factory;
            Mapper = mapper;
        }

        public async Task<Tweet> ByIdAsync(string id)
        {
            var client = Factory.CreateClient("Twitter");

            var response = await client.GetAsync(new Uri($"/2/tweets/{id}", UriKind.Relative)).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                return new Tweet();
            }

            var content = await response.Content.ReadAsStringAsync()
                .ContinueWith(read => read.Result.Deserialize<Models.Tweet>())
                .ConfigureAwait(false);

            return Mapper.Map<Tweet>(content);
        }
    }
}
