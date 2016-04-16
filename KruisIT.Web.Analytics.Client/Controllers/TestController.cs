using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KruisIT.Web.Analytics.Client.Controllers
{
	[KruisIT.Web.Analytics.Attributes.Analytics("DevelopmentDb", "TestApp")]
	public class TestController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}