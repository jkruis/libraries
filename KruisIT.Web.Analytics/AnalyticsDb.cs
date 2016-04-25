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

		public List<Models.Aggregate> GetVisitsByDay(Models.Filter filter)
		{
			string sql = "select cast(StartTime as date) as [Date], count(*) as [Count], null as Location from Analytics_Visits";
			if (!String.IsNullOrEmpty(filter.Website))
			{
				sql += String.Format(" where Website = '{0}'", filter.Website);
			}
			else
			{
				sql += " where Website is null";
			}

			sql += String.Format(" and StartTime > '{0}' and StartTime < '{1}'", filter.StartDate.Value.ToString("yyyy-MM-dd"), filter.EndDate.Value.ToString("yyyy-MM-dd") + " 23:59:59");

			if (!String.IsNullOrEmpty(filter.Location)) {
				sql += String.Format(" and Location = '{0}'", filter.Location);
			}

			if (!String.IsNullOrEmpty(filter.Visitor)) {
				sql += String.Format(" and IpAddress = '{0}'", filter.Visitor);
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

			if (aggregates.Any())
			{
				while (aggregates[0].Date > filter.StartDate)
				{
					aggregates.Insert(0, new Models.Aggregate() { Date = aggregates[0].Date.AddDays(-1), Count = 0 });
				}

				while (aggregates[aggregates.Count - 1].Date < filter.EndDate.Value.Date)
				{
					aggregates.Insert(aggregates.Count, new Models.Aggregate() { Date = aggregates[aggregates.Count - 1].Date.AddDays(1), Count = 0 });
				}
			}
			else
			{
				for (DateTime date = filter.StartDate.Value; date <= filter.EndDate; date = date.AddDays(1))
				{
					aggregates.Insert(aggregates.Count, new Models.Aggregate() { Date = date, Count = 0 });
				}
			}

			return aggregates;
		}
	
	}
}
