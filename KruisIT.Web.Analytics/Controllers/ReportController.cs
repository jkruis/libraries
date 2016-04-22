using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KruisIT.Web.Analytics.Controllers
{
	// todo : adds RazorGeneratorMvcStart to projects when the package is installed. shouldn't!

	// todo : combine with known users/ip-addresses, if possible.

	public class ReportController : Controller
	{
		AnalyticsDb db;
		string NameOrConnectionString = null;
		string SiteName = null;

		public ReportController(string nameOrConnectionString) : this(nameOrConnectionString, null) { }

		public ReportController(string nameOrConnectionString, string siteName)
		{
			NameOrConnectionString = nameOrConnectionString;
			SiteName = siteName;

			db = new AnalyticsDb(NameOrConnectionString);
		}

		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			base.OnActionExecuting(filterContext);

			string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
			ViewBag.Url = "/" + controllerName + "/";
		}

		public string Test()
		{
			return "test";
		}

		ViewResult FindView(string name, object model)
		{
			ViewEngineResult result = ViewEngines.Engines.FindView(ControllerContext, name, null);
			if (null != result.View)
			{
				return View(model);
			}
			else
			{
				return View(String.Format("~/Views/Report/{0}.cshtml", name), model);
			}
		}

		public ActionResult Index(Models.Filter filter)
		{
			if (!String.IsNullOrEmpty(SiteName)) filter.Website = SiteName;

			List<string> websites = null;
			if (String.IsNullOrEmpty(filter.Website))
			{
				websites = db.Analytics_Visits.Select(v => v.Website).Distinct().ToList();
			}
			else
			{
				websites = db.Analytics_Visits.Where(v => v.Website == filter.Website).Select(v => v.Website).Distinct().ToList();
			}
			Models.CurrentList<string> model = new Models.CurrentList<string>() { Filter = filter, Data = websites };

			return FindView("Index", model);
		}

		public ActionResult Website(Models.Filter filter)
		{
			Models.Current<string> model = new Models.Current<string>() { Filter = filter, Data = filter.Website };

			return FindView("Website", model);
		}

		public ActionResult Visitors(Models.Filter filter)
		{
			var visitors = db.Analytics_Visits.Where(v => v.Website == filter.Website && (filter.Location == null || filter.Location == v.Location) && (filter.Visitor == null || filter.Visitor == v.IpAddress)).Select(v => new Models.Visitor() { Address = v.IpAddress, Website = filter.Website }).Distinct().OrderBy(v => v).ToList();
			Models.CurrentList<Models.Visitor> model = new Models.CurrentList<Models.Visitor>() { Filter = filter, Data = visitors };

			return FindView("Visitors", model);
		}

		public ActionResult Locations(Models.Filter filter)
		{
			var locations = db.Analytics_Visits.Where(v => v.Website == filter.Website && (filter.Location == null || filter.Location == v.Location) && (filter.Visitor == null || filter.Visitor == v.IpAddress)).Select(v => new Models.Location() { Url = v.Location, Website = filter.Website }).Distinct().OrderBy(l => l).ToList();
			Models.CurrentList<Models.Location> model = new Models.CurrentList<Models.Location>() { Filter = filter, Data = locations };

			return FindView("Locations", model);
		}

		public ActionResult Aggregates(Models.Filter filter)
		{
			var aggregates = db.GetVisitsByDay(filter.Website, filter.Location, filter.Visitor);

			for (int i = 1; i < aggregates.Count; i++)
			{
				if (aggregates[i].Date - aggregates[i - 1].Date > new TimeSpan(1, 0, 0, 0))
				{
					aggregates.Insert(i, new Models.Aggregate() { Date = aggregates[i - 1].Date.AddDays(1), Count = 0 });
				}
			}
			Models.CurrentList<Models.Aggregate> model = new Models.CurrentList<Models.Aggregate>() { Filter = filter, Data = aggregates };

			return FindView("Aggregates", model);
		}

		public FileStreamResult Resource(string id)
		{
			id = id.Replace("_", ".");

			string resourceName = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames().ToList().FirstOrDefault(f => f.EndsWith(id));
			return new FileStreamResult(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName), GetMIMEType(id));
		}

		private string GetMIMEType(string fileId)
		{
			if (fileId.EndsWith(".js"))
			{
				return "text/javascript";
			}
			else if (fileId.EndsWith(".css"))
			{
				return "text/css";
			}
			else if (fileId.EndsWith(".jpg"))
			{
				return "image/jpeg";
			}
			return "text";
		}

	
	}
}
