using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KruisIT.Web.Analytics.Client.Controllers
{
	public class HomeController : KruisIT.Web.Analytics.Controllers.ReportController
	{
		public HomeController() : base("DevelopmentDb") { }

	}
}