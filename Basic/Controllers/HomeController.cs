using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Basic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        [Authorize(Policy = "Claim.DOB")]
        public IActionResult SecretPolicy()
        {
            return View("Secret");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult SecretRole()
        {
            return View("Secret");
        }

        public IActionResult Authenticate()
        {
            var harveyClaim = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Harvey"),
                new Claim(ClaimTypes.Email, "harvey@gmail.com"),
                new Claim(ClaimTypes.DateOfBirth, "28/08/1998"),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var harveyIdentity = new ClaimsIdentity(harveyClaim, "Harvey Identity");
            var userPrincipal = new ClaimsPrincipal(new[] { harveyIdentity });

            HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index");
        }
    }
}