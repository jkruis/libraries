using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KruisIT.Object.Extensions;

namespace KruisIT.Object.Extensions.Test
{
	[TestClass]
	public class ExceptionExtensionsTest
	{
		[TestClass]
		public class FullMessage : ExceptionExtensionsTest
		{

			[TestMethod]
			public void ThrowsOnNullReference()
			{
				bool hasThrown = false;

				try
				{
					Exception valueIn = null;
					string result = valueIn.FullMessage();
				}
				catch (NullReferenceException ex)
				{
					hasThrown = true;
				}
				Assert.IsTrue(hasThrown);
			}

			[TestMethod]
			public void ReturnsEmptyMessage()
			{
				string message = "";

				Exception valueIn = new Exception(message);
				string result = valueIn.FullMessage();
				Assert.AreEqual(message, result);
			}

			[TestMethod]
			public void ReturnsSingleMessage()
			{
				string message = "test exception message";

				Exception valueIn = new Exception(message);
				string result = valueIn.FullMessage();
				Assert.AreEqual(message, result);
			}

			[TestMethod]
			public void ReturnsMultipleMessage()
			{
				string message1 = "test exception message";
				string message2 = "test another exception message";

				Exception valueIn = new Exception(message1, new Exception(message2));
				string result = valueIn.FullMessage();
				Assert.AreEqual(message1 + "; " + message2, result);
			}

		}

	}
}
