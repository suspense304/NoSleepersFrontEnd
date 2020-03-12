using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NoSleepers.Core;
using NoSleepers.Data;

namespace NoSleepers
{
    public class StoryModel : PageModel
    {
        private readonly IStoryRepo _storyRepo;

        public List<Story> Stories { get; set; }

        public double Rating { get; set; }

        public StoryModel(IStoryRepo storyRepo)
        {
            _storyRepo = storyRepo;
        }

        public void OnGet()
        {
            Stories = _storyRepo.GetNewest(10);
        }
    }
}