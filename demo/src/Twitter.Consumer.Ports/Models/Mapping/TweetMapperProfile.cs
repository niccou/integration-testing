using AutoMapper;

namespace Twitter.Consumer.Ports.Models.Mapping
{
    public class TweetMapperProfile : Profile
    {
        public TweetMapperProfile()
        {
            CreateMap<Tweet, Core.ReadingTweets.Tweet>()
                .ForMember(_=>_.Message, x=>x.MapFrom(_=>_.Text))
                .ForMember(_=>_.Date, x=>x.MapFrom(_=>_.CreatedAt));
        }
    }
}
