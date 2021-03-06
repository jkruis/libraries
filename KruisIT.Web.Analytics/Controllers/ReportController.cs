﻿using System;
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

	// todo : show referrer, user agent info. allow filtering.

	// todo : create a line chart with http://www.chartjs.org/docs/#line-chart-example-usage

	public class ReportController : Controller
	{
		Database.AnalyticsDb db;
		string NameOrConnectionString = null;
		string SiteName = null;

		public ReportController(string nameOrConnectionString) : this(nameOrConnectionString, null) { }

		public ReportController(string nameOrConnectionString, string siteName)
		{
			Database.ConnectionHolder.NameOrConnectionString = nameOrConnectionString;

			NameOrConnectionString = nameOrConnectionString;
			SiteName = siteName;

			db = new Database.AnalyticsDb(NameOrConnectionString);
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

		Models.Filter SetFilterDefaults(Models.Filter filter)
		{
			if (!String.IsNullOrEmpty(SiteName)) filter.Website = SiteName;
			return filter;
		}

		IQueryable<Models.Visit> FilteredVisits(Models.Filter filter)
		{
			DateTime startD = filter.StartDate.HasValue ? filter.StartDate.Value : DateTime.Now.AddDays(-65);
			DateTime endD = filter.EndDate.HasValue ? filter.EndDate.Value.Date.AddDays(1) : DateTime.Now;

			var visits = db.Analytics_Visits.Where(v =>
				v.StartTime > startD
				&& v.StartTime < endD
				&& v.Website == filter.Website 
				&& (filter.Location == null || filter.Location == v.Location) 
				&& (filter.Visitor == null || filter.Visitor == v.IpAddress)
				);
			return visits;
		}

		public ActionResult Index(Models.Filter filter)
		{
			filter = SetFilterDefaults(filter);

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

		public ActionResult MostViewed(Models.Filter filter)
		{
			int itemCount = 20;
			filter = SetFilterDefaults(filter);

			var data = FilteredVisits(filter).GroupBy(v => v.Location).Select(g => new Models.Aggregate() { Location = g.Key, Count = g.Count() }).OrderByDescending(a => a.Count).Take(itemCount).ToList();
			Models.CurrentList<Models.Aggregate> model = new Models.CurrentList<Models.Aggregate>() { Title = "Most Viewed", Filter = filter, Data = data };

			return FindView("AggregatesList", model);
		}

		public ActionResult Aggregates_Visitors(Models.Filter filter)
		{
			filter = SetFilterDefaults(filter);

			if (null == filter.EndDate) filter.EndDate = DateTime.Now;
			if (null == filter.StartDate) filter.StartDate = filter.EndDate.Value.AddDays(-35);

			var aggregates = db.GetVisitorsByDay(filter);

			Models.CurrentList<Models.Aggregate> model = new Models.CurrentList<Models.Aggregate>() { Title = "Daily Unique Visitors", Filter = filter, Data = aggregates };
			return FindView("Aggregates", model);
		}

		public ActionResult Aggregates_Visits(Models.Filter filter)
		{
			filter = SetFilterDefaults(filter);

			if (null == filter.EndDate) filter.EndDate = DateTime.Now;
			if (null == filter.StartDate) filter.StartDate = filter.EndDate.Value.AddDays(-35);

			var aggregates = db.GetVisitsByDay(filter);

			Models.CurrentList<Models.Aggregate> model = new Models.CurrentList<Models.Aggregate>() { Title = "Page Views", Filter = filter, Data = aggregates };
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
