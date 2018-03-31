using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Noddle.Web.Models;

namespace Noddle.Web.Controllers
{
    public class ClockController : Controller
    {
        private readonly IRotator _rotator;
        public ClockController(IRotator rotator)
        {
            _rotator = rotator ?? throw new ArgumentNullException(nameof(rotator));
        }

        public IActionResult Display()
        {
            ViewData["NextUrl"] = _rotator.Next("Clock", "Display");

            return View();
        }
    }
}


