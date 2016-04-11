using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KruisIT.Data
{
	public class PagerModel
	{
		public int ItemCount { get; set; }
		public int PageSize { get; set; }
		public int CurrentPage { get; set; }
		public int PageCount { get; set; }
	}
}