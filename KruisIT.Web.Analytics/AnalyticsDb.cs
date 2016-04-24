using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruisIT.Web.Analytics
{
	class AnalyticsDb : DbContext
	{
		public AnalyticsDb(string NameOrConnectionString) : base(NameOrConnectionString) { }

#if DEBUG
		// for making migrations only
		public AnalyticsDb() : base(@"Data Source=WIN-EG3CNDSH5RQ\SQL2012;Initial Catalog=KruisIT.Web.Analytics;User Id=dev;Password=dev;MultipleActiveResultSets=True;") { }
#endif

		public DbSet<Models.Visit> Analytics_Visits { get; set; }

		public List<Models.Aggregate> GetVisitsByDay(DateTime startDate, DateTime endDate, string website, string location, string visitor)
		{
			string sql = "select cast(StartTime as date) as [Date], count(*) as [Count], null as Location from Analytics_Visits";
			if (!String.IsNullOrEmpty(website))
			{
				sql += String.Format(" where Website = '{0}'", website);
			}
			else
			{
				sql += " where Website is null";
			}

			sql += String.Format(" and StartTime > '{0}' and StartTime < '{1}'", startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd") + " 23:59:59");

			if (!String.IsNullOrEmpty(location)) {
				sql += String.Format(" and Location = '{0}'", location);
			}

			if (!String.IsNullOrEmpty(visitor)) {
				sql += String.Format(" and IpAddress = '{0}'", visitor);
			}

			sql += " group by cast(StartTime as date)";
			var aggregates = this.Database.SqlQuery<Models.Aggregate>(sql).ToList();

			for (int i = 1; i < aggregates.Count; i++)
			{
				if (aggregates[i].Date - aggregates[i - 1].Date > new TimeSpan(1, 0, 0, 0))
				{
					aggregates.Insert(i, new Models.Aggregate() { Date = aggregates[i - 1].Date.AddDays(1), Count = 0 });
				}
			}

			while (aggregates[0].Date > startDate)
			{
				aggregates.Insert(0, new Models.Aggregate() { Date = aggregates[0].Date.AddDays(-1), Count = 0 });
			}

			while (aggregates[aggregates.Count - 1].Date < endDate.Date)
			{
				aggregates.Insert(aggregates.Count, new Models.Aggregate() { Date = aggregates[aggregates.Count - 1].Date.AddDays(1), Count = 0 });
			}

			//aggregates = aggregates.Skip(aggregates.Count - days).ToList();
			return aggregates;
		}
	
	}
}
