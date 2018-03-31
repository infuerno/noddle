using System;

namespace Noddle.Web.Models
{
    public class RotatorViewModel
    {
        public string NextControllerName { get; set; }

        public string NextActionName { get; set; }

        public RotatorViewModel(string nextUrl)
        {
            string[] urlParts = nextUrl.Split("/");
            NextControllerName = urlParts[1];
            NextActionName = urlParts[0];
        }

        public RotatorViewModel(string nextController, string nextAction)
        {
            NextControllerName = nextController;
            NextActionName = nextAction;
        }
    }
}