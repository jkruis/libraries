using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruisIT.Web.Analytics.Models
{
	public class Filter
	{
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public string Website { get; set; }
		public string Location { get; set; }
		public string Visitor { get; set; }
	}
}
