namespace Twitter.Consumer.Api.Models
{
    public record Response
    {
        public string Status { get; init; } = "";
        public string Message { get; init; } = "";
    }
}
