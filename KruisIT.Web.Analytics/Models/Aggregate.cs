using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruisIT.Web.Analytics.Models
{
	public class Aggregate
	{
		public DateTime Date { get; set; }
		public int Count { get; set; }
		public string Location { get; set; }
	}
}
