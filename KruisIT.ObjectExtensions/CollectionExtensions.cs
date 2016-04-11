using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruisIT.Object.Extensions
{
    public static class CollectionExtensions
    {
		public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> @this, int count)
		{
			if (null == @this)
			{
				throw new NullReferenceException("Object reference not set to an instance of an object.");
			}

			return @this.Skip(Math.Max(0, @this.Count() - count));
		}
	}
}
