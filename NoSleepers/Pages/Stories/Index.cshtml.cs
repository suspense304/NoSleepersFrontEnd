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
        private readonly NoSleepersDbContext _dbContext;

        public IEnumerable<Story> Stories { get; set; }

        public StoryModel(NoSleepersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            Stories = _dbContext.Stories.Take(5).OrderByDescending(s => s.Date).OrderByDescending(s => s.Score).ToList();
        }
    }
}