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
    public class CreateModel : PageModel
    {
        private readonly NoSleepersDbContext _dbContext;

        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string RedditAccount { get; set; }

        public string ErrMessage { get; set; }

        public CreateModel(NoSleepersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            return Redirect("/");
        }
    }
}