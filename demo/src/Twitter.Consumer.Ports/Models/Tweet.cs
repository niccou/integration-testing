using System;
using System.Text.Json.Serialization;

namespace Twitter.Consumer.Ports.Models
{
    public class Tweet
    {
        [JsonPropertyName("author_id")]
        public string AuthorId { get; init; } = "";

        [JsonPropertyName("conversation_id")]
        public string ConversationId { get; init; } = "";

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; init; } = DateTime.MinValue;

        public string Id { get; init; } = "";

        public string Text { get; init; } = "";
    }
}