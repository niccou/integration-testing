using System.Threading.Tasks;

namespace Twitter.Consumer.Core.ReadingTweets
{
    public interface ISearchTweet
    {
        Task<Tweet> ByIdAsync(string id);
    }
}
