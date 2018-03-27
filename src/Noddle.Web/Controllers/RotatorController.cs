using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Noddle.Web.Models;

namespace Noddle.Web.Controllers
{
    public class RotatorController : Controller
    {
        private readonly List<string> _rotationUrls;
        private readonly string _defaultUrl;

        public RotatorController()
        {
            _rotationUrls = new List<string>() {"~/Clock/View1", "~/Clock/View2", "~/Clock/View3", "~/Clock/View4"};            
            _defaultUrl = _rotationUrls[0];
        }

        public IActionResult Next()
        {
            string referrerHeader = Request.Headers["Referer"];
            if (string.IsNullOrWhiteSpace(referrerHeader))
                return Redirect(_defaultUrl);

            var referrerUrl = new Uri(referrerHeader);
            var localReferrerUrl = $"~{referrerUrl.LocalPath}";
            var nextUrl = GetNextUrl(localReferrerUrl);

            return Redirect(nextUrl);
        }

        private string GetNextUrl(string currentUrl)
        {
            var index = FindUrlInRotationUrls(currentUrl);

            if (index == -1)
                return _defaultUrl;

            return _rotationUrls[(index + 1) % _rotationUrls.Count];
        }

        private int FindUrlInRotationUrls(string url)
        {
            return _rotationUrls.IndexOf(url);
            // for(int i = 0, n = _rotationUrls.Count; i < n; i++)
            // {
            //     if (_rotationUrls[i].Contains(url))
            //         return i;
            // }
            // return -1;
        }
    }
}
