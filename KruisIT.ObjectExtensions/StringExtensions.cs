using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruisIT.Object.Extensions
{
	public static class StringExtensions
	{
		public static bool Contains(this string @this, string value, StringComparison comparisonType)
		{
			if (null == @this)
			{
				throw new NullReferenceException("Object reference not set to an instance of an object.");
			}
			else if (null == value)
			{
				throw new ArgumentNullException("Value cannot be null.");
			}

			return @this.IndexOf(value, comparisonType) >= 0;
		}

		public static bool ContainsAll(this string @this, params string[] values)
		{
			if (null == @this)
			{
				throw new NullReferenceException("Object reference not set to an instance of an object.");
			}
			else if (null == values)
			{
				throw new ArgumentNullException("Value cannot be null.");
			}
			else if (0 == values.Length)
			{
				throw new ArgumentNullException("Value cannot be empty.");
			}

			if (!string.IsNullOrEmpty(@this) || values.Length > 0)
			{
				foreach (string value in values)
				{
					if (!@this.Contains(value, StringComparison.OrdinalIgnoreCase))
						return false;
				}
			}
			return true;
		}

		public static bool ContainsAny(this string @this, params string[] values)
		{
			if (null == @this)
			{
				throw new NullReferenceException("Object reference not set to an instance of an object.");
			}
			else if (null == values)
			{
				throw new ArgumentNullException("Value cannot be null.");
			}
			else if (0 == values.Length)
			{
				throw new ArgumentNullException("Value cannot be empty.");
			}

			if (!string.IsNullOrEmpty(@this) || values.Length > 0)
			{
				foreach (string value in values)
				{
					if (@this.Contains(value, StringComparison.OrdinalIgnoreCase))
						return true;
				}
			}
			return false;
		}

		public static string ReplaceFirst(this string @this, string search, string replace)
		{
			int pos = @this.IndexOf(search);
			if (pos < 0)
			{
				return @this;
			}
			return @this.Substring(0, pos) + replace + @this.Substring(pos + search.Length);
		}
	}
}
