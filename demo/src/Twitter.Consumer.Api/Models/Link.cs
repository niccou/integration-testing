using System;
using System.Net.Http;

namespace Twitter.Consumer.Api.Models
{
    public record Link
    {
        public Uri Uri { get; init; } = new Uri("/", UriKind.Relative);
        public string Rel { get; init; } = "";
        public string Method { get; init; } = HttpMethod.Get.Method;
    }
}
