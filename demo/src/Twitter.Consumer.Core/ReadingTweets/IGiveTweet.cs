using System.Threading.Tasks;

namespace Twitter.Consumer.Core.ReadingTweets
{
    public interface IGiveTweet
    {
        Task<Tweet> SearchByIdAsync(string id);
    }
}
