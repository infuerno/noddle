using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Noddle.Web.Controllers
{
    public class CalendarController : Controller
    {
        private readonly IRotator _rotator;
        public CalendarController(IRotator rotator)
        {
            _rotator = rotator ?? throw new ArgumentNullException(nameof(rotator));
        }

        public IActionResult Daily()
        {
            ViewData["NextUrl"] = _rotator.Next("Calendar", "Daily");

            return View();
        }

        public IActionResult Weekly()
        {
            ViewData["NextUrl"] = _rotator.Next("Calendar", "Weekly");
            return View();
        }
    }
}