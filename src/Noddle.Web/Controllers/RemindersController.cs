using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Noddle.Web.Controllers
{
    public class RemindersController : Controller
    {
        private readonly IRotator _rotator;
        public RemindersController(IRotator rotator)
        {
            _rotator = rotator ?? throw new ArgumentNullException(nameof(rotator));
        }

        public IActionResult Display()
        {
            ViewData["NextUrl"] = _rotator.Next("Reminders", "Display");
            return View();
        }
    }
}