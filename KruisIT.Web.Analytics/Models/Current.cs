using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruisIT.Web.Analytics.Models
{
	public class CurrentList<T>
	{
		public Filter Filter { get; set; }
		public List<T> Data { get; set; }
	}

	public class Current<T>
	{
		public Filter Filter { get; set; }
		public T Data { get; set; }
	}

}
