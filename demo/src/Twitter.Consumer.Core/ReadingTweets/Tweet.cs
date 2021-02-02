using System;

namespace Twitter.Consumer.Core.ReadingTweets
{
    public record Tweet
    {
        public string Id { get; init; } = "";
        public string AuthorId { get; init; } = "";
        public string Message { get; init; } = "";
        public DateTime Date { get; init; }
    }
}
