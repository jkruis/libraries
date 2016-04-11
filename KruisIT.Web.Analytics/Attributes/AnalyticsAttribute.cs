using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace KruisIT.Web.Analytics.Attributes
{
	public class AnalyticsAttribute : ActionFilterAttribute
	{
		AnalyticsDb db;
		string NameOrConnectionString = null;
		string Website = null;
		int? VisitId = null;

		public AnalyticsAttribute(string nameOrConnectionString) : this(nameOrConnectionString, null) { }

		public AnalyticsAttribute(string nameOrConnectionString, string siteName)
		{
			NameOrConnectionString = nameOrConnectionString;
			Website = siteName;
		}

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			base.OnActionExecuting(filterContext);

			try
			{
				var visit = new Models.Visit()
				{
					StartTime = DateTime.UtcNow,
					IpAddress = filterContext.HttpContext.Request.UserHostAddress,
					Website = Website,
					Location = filterContext.HttpContext.Request.RawUrl
				};

				db = new AnalyticsDb(NameOrConnectionString);
				db.Analytics_Visits.Add(visit);
				db.SaveChanges();

				VisitId = visit.Id;
			}
			catch (Exception ex)
			{
				LogError(ex);
			}
		}

		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			base.OnActionExecuted(filterContext);

			try
			{
				if (null != VisitId)
				{
					var visit = db.Analytics_Visits.Find(VisitId);
					visit.EndTime = DateTime.UtcNow;
					db.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				LogError(ex);
			}
		}

		void LogError(Exception ex)
		{
			// todo : log analytics error somewhere

		}
	
	}
}
