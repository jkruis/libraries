using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(KruisIT.Web.Analytics.App_Start.DatabaseStart), "Start")]

namespace KruisIT.Web.Analytics.App_Start
{
	public static class DatabaseStart
	{
		public static void Start()
		{
			System.Data.Entity.Database.SetInitializer<Database.AnalyticsDb>(new System.Data.Entity.MigrateDatabaseToLatestVersion<Database.AnalyticsDb, KruisIT.Web.Analytics.Migrations.Configuration>());
		}
	}
}
