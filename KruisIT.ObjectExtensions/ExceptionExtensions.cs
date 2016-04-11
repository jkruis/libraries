using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruisIT.Object.Extensions
{
	public static class ExceptionExtensions
	{
		public static string FullMessage(this Exception @this)
		{
			if (null == @this)
			{
				throw new NullReferenceException("Object reference not set to an instance of an object.");
			}

			string message = @this.Message;
			while (null != @this.InnerException)
			{
				@this = @this.InnerException;
				message += "; " + @this.Message;
			}
			return message;
		}
	}
}
