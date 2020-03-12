using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoSleepers.Data;

namespace NoSleepers.Controllers
{
    [Route("api/ratings")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IStoryRepo _storyRepo;

        public RatingsController(IStoryRepo storyRepo)
        {
            _storyRepo = storyRepo;
        }

        [HttpPost("writeRating/{storyId:int}/{rating:int}")]
        public async Task<IActionResult> WriteRating([FromRoute] int storyId, [FromRoute] int rating)
        {
            //var username = this.HttpContext.User.Identity.Name
            WriteRatingDto dto = new WriteRatingDto();
            dto.UserId = 1;
            dto.Score = rating;
            await _storyRepo.WriteRatingForStory(storyId, dto.UserId, dto.Score);
            return Ok();
        }
    }

    public class WriteRatingDto
    {
        public int UserId { get; set; }
        public int Score { get; set; }
    }
}