using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noddle.Web
{
    public interface IRotator
    {
        string Next(string currentUrl);
        string Next(string currentController, string currentAction);
    }

    public class Rotator : IRotator
    {
        private static readonly List<string> _rotationUrls = new List<string> { "~/Clock/Display", "~/Calendar/Daily", "~/Calendar/Weekly", "~/Reminders/Display" };
        private static readonly string _defaultUrl = _rotationUrls[0];

        public string Next(string currentUrl)
        {
            if (string.IsNullOrWhiteSpace(currentUrl))
                return _defaultUrl;

            var referrerUrl = new Uri(currentUrl);
            //TODO better way to do this?
            var localReferrerUrl = $"~{referrerUrl.LocalPath}";
            var nextUrl = GetNextUrl(localReferrerUrl);

            return nextUrl;
        }

        public string Next(string controller, string action)
        {
            if (string.IsNullOrWhiteSpace(controller) || string.IsNullOrWhiteSpace(action))
                return _defaultUrl;

            var currentUrl = $"~/{controller}/{action}";
            var nextUrl = GetNextUrl(currentUrl);

            return nextUrl;
        }

        private string GetNextUrl(string currentUrl)
        {
            var index = FindUrlInRotationUrls(currentUrl);

            // current url not found, return default
            if (index == -1)
                return _defaultUrl;

            // current url found, return next in list, wrapping round to the beginning if we're at the end
            return _rotationUrls[(index + 1) % _rotationUrls.Count];
        }

        private int FindUrlInRotationUrls(string url)
        {
            return _rotationUrls.IndexOf(url);
        }
    }
}
