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
    public class AuthorModel : PageModel
    {
        private readonly NoSleepersDbContext _dbContext;

        public IEnumerable<Author> Authors { get; set; }

        public AuthorModel(NoSleepersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            Authors = _dbContext.Authors.ToList().OrderBy(s => s.Name).ToList();        
        }

    }
}