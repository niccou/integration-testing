using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using Twitter.Consumer.Core.ReadingTweets;

namespace Twitter.Consumer.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    [ApiVersion("2")]
    public class TweetController : ControllerBase
    {
        private IGiveTweet GiveTweet { get; }
        private IMapper Mapper { get; }

        public TweetController(IGiveTweet giveTweet, IMapper mapper)
        {
            GiveTweet = giveTweet;
            Mapper = mapper;
        }

        [HttpGet("{id}", Name = nameof(GetTweetByIdAsync))]
        [MapToApiVersion("1")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Models.Tweet))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetTweetByIdAsync([Required, FromRoute] string id)
        {
            var result = await GiveTweet.SearchByIdAsync(id)
                .ContinueWith(search => Mapper.Map<Models.Tweet>(search.Result)).ConfigureAwait(false);

            if (result is not null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [Authorize]
        [HttpGet("{id}", Name = nameof(GetTweetByIdAsyncV2))]
        [MapToApiVersion("2")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Models.Tweet))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetTweetByIdAsyncV2([Required, FromRoute] string id)
        {
            var result = await GiveTweet.SearchByIdAsync(id)
                .ContinueWith(search => Mapper.Map<Models.Tweet>(search.Result)).ConfigureAwait(false);

            if (result is not null)
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}
