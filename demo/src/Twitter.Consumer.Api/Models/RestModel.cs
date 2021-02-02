using System.Collections.Generic;

namespace Twitter.Consumer.Api.Models
{
    public record RestModel
    {
        public ICollection<Link> Links { get; init; } = new List<Link>();
    }
}
