using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KruisIT.Data
{

	public class PagedDataModel<T>
	{
		public List<T> Data { get; set; }
		public PagerModel PagerInfo { get; set; }

		//public PagedDataModel(List<T> data, int pageSize, int? currentPage) : this(data, pageSize, currentPage, false) { }

		public PagedDataModel(List<T> data, int pageSize, int? currentPage)
		{
			if (null != data)
			{
				PagerInfo = new PagerModel() { ItemCount = data.Count, PageSize = pageSize, PageCount = (int)Math.Ceiling((double)data.Count / pageSize), CurrentPage = currentPage ?? 1 };

				int skip = (PagerInfo.CurrentPage - 1) * PagerInfo.PageSize;
				Data = data.Skip(skip).Take(PagerInfo.PageSize).ToList();
			}
			else
			{
				PagerInfo = new PagerModel() { ItemCount = 0, PageSize = 1, PageCount = 1, CurrentPage = 1 };
				Data = null;
			}
		}
	}
}