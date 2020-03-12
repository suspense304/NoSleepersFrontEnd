using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NoSleepers.Data;
using NoSleepers.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace NoSleepers
{
    public class LoginModel : PageModel
    {
        private readonly NoSleepersDbContext _dbContext;

        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public string ErrMessage { get; set; }

        public void OnGet()
        {

        }

        public LoginModel(NoSleepersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> OnPost()
        {
            var claimsIdentities = new List<ClaimsIdentity>();
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, "dhantke@advantagetech.biz"),
                new Claim("UserId", "1", ClaimValueTypes.Integer32),
            };
            var identity = new ClaimsIdentity(claims);
            var principal = new ClaimsPrincipal(claimsIdentities);
            await HttpContext.SignInAsync(principal);
            return Page();
        }
    }
}