using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Noddle.Web.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Noddle.Web.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly ILogger _logger;

        public AccountController(
            ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
 
        [AllowAnonymous]
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return Content("Access Denied");
        }
 
        [AllowAnonymous]
        [HttpGet]
        public IActionResult ExternalLogin(string returnUrl = null)
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = returnUrl ?? "/Clock/Display"
            };
 
            return Challenge(properties);
        }
 
 
 
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
 
            return RedirectToAction(nameof(ClockController.Display), "Clock");
        }
 
 
        private IActionResult GoToReturnUrl(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
