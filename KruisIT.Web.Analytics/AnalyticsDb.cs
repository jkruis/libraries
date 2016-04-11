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

		public DbSet<Models.Visit> Analytics_Visits { get; set; }

		public List<Models.Aggregate> GetVisitsByDay(string website, string location, string visitor)
		{
			// todo : fix for null value
			string sql = String.Format("select cast(StartTime as date) as [Date], count(*) as [Count], null as Location from Analytics_Visits where Website = '{0}'", website);

			if (!String.IsNullOrEmpty(location)) {
				sql += String.Format(" and Location = '{0}'", location);
			}

			if (!String.IsNullOrEmpty(visitor)) {
				sql += String.Format(" and IpAddress = '{0}'", visitor);
			}

			sql += " group by cast(StartTime as date)";
			return this.Database.SqlQuery<Models.Aggregate>(sql).ToList();
		}
	
	}
}
