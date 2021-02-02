namespace Twitter.Consumer.Api.Models
{
    public record JWTSettings
    {
        public string ValidAudience { get; init; } = "";
        public string ValidIssuer { get; init; } = "";
        public string Secret { get; init; } = "";
    }
}
