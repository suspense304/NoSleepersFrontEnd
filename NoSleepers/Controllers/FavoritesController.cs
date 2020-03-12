using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoSleepers.Data;

namespace NoSleepers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly IStoryRepo _storyRepo;

        public FavoritesController(IStoryRepo storyRepo)
        {
            _storyRepo = storyRepo;
        }

        [HttpPost("setFav/{storyId:int}")]
        public async Task<IActionResult> WriteRating([FromRoute] int storyId, [FromBody] SetFavoriteDto favDto)
        {
            await _storyRepo.SetFavorite(storyId, favDto.UserId);
            return Ok();
        }

    }

    public class SetFavoriteDto
    {
        public int UserId { get; set; }
    }
}