using System;
using Microsoft.AspNetCore.Mvc;
using Noddle.Web.Models;

namespace Noddle.Web.Controllers
{

    public class RotatorController : Controller
    {
        private readonly IRotator _rotator;

        public RotatorController(IRotator rotator)
        {
            _rotator = rotator ?? throw new ArgumentNullException(nameof(rotator));
        }

        public IActionResult Display()
        {
            string referrerHeader = Request.Headers["Referer"];
            var nextUrl = _rotator.Next(referrerHeader);
            var model = new RotatorViewModel(nextUrl);
            return View(model);
        }

        public IActionResult Next()
        {
            string referrerHeader = Request.Headers["Referer"];
            var nextUrl = _rotator.Next(referrerHeader);
            return Redirect(nextUrl);
        }
    }
}
