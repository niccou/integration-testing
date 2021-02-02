using AutoMapper;

namespace Twitter.Consumer.Api.Models.Mapping
{
    public class TweetMapperProfile : Profile
    {
        public TweetMapperProfile()
        {
            CreateMap<Core.ReadingTweets.Tweet, Tweet>();
        }
    }
}
