using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KruisIT.ObjectExtensions;

namespace KruisIT.ObjectExtensions.Test
{
	[TestClass]
	public class StringExtensionsTest
	{

		[TestClass]
		public class Contains : StringExtensionsTest
		{
			[TestMethod]
			public void ThrowsOnNullReference()
			{
				bool hasThrown = false;

				try
				{
					string valueIn = null;
					bool result = valueIn.Contains("this", StringComparison.CurrentCulture);
				}
				catch (NullReferenceException ex)
				{
					hasThrown = true;
				}
				Assert.IsTrue(hasThrown);
			}

			[TestMethod]
			public void ThrowsOnNullValue()
			{
				bool hasThrown = false;

				try
				{
					string valueIn = "test this string";
					bool result = valueIn.Contains(null, StringComparison.CurrentCulture);
				}
				catch (ArgumentNullException ex)
				{
					hasThrown = true;
				}
				Assert.IsTrue(hasThrown);
			}

			[TestMethod]
			public void ReturnsTrueOnCaseMatch()
			{
				string valueIn = "test this string";
				bool result = valueIn.Contains("this", StringComparison.CurrentCulture);
				Assert.IsTrue(result);
			}

			[TestMethod]
			public void ReturnsTrueOnCaseIgnore()
			{
				string valueIn = "test this string";
				bool result = valueIn.Contains("THIS", StringComparison.CurrentCultureIgnoreCase);
				Assert.IsTrue(result);
			}

			[TestMethod]
			public void ReturnsFalseOnCaseMismatch()
			{
				string valueIn = "test this string";
				bool result = valueIn.Contains("THIS", StringComparison.CurrentCulture);
				Assert.IsFalse(result);
			}

			[TestMethod]
			public void ReturnsFalseOnNoMatch()
			{
				string valueIn = "test this string";
				bool result = valueIn.Contains("that", StringComparison.CurrentCulture);
				Assert.IsFalse(result);
			}

		}

		[TestClass]
		public class ContainsAll : StringExtensionsTest
		{
			[TestMethod]
			public void ThrowsOnNullReference()
			{
				bool hasThrown = false;

				try
				{
					string valueIn = null;
					bool result = valueIn.ContainsAll("this", "that");
				}
				catch (NullReferenceException ex)
				{
					hasThrown = true;
				}
				Assert.IsTrue(hasThrown);
			}

			[TestMethod]
			public void ThrowsOnNullValue()
			{
				bool hasThrown = false;

				try
				{
					string valueIn = "test this string";
					bool result = valueIn.ContainsAll(null);
				}
				catch (ArgumentNullException ex)
				{
					hasThrown = true;
				}
				Assert.IsTrue(hasThrown);
			}

			[TestMethod]
			public void ThrowsOnNoValue()
			{
				bool hasThrown = false;

				try
				{
					string valueIn = "test this string";
					bool result = valueIn.ContainsAll();
				}
				catch (ArgumentNullException ex)
				{
					hasThrown = true;
				}
				Assert.IsTrue(hasThrown);
			}

			[TestMethod]
			public void ReturnsTrueOnMatch()
			{
				string valueIn = "test this string";
				bool result = valueIn.ContainsAll("this", "test");
				Assert.IsTrue(result);
			}

			[TestMethod]
			public void ReturnsFalseOnNoMatch()
			{
				string valueIn = "test this string";
				bool result = valueIn.ContainsAll("this", "that", "there");
				Assert.IsFalse(result);
			}

		}

		[TestClass]
		public class ContainsAny : StringExtensionsTest
		{
			[TestMethod]
			public void ThrowsOnNullReference()
			{
				bool hasThrown = false;

				try
				{
					string valueIn = null;
					bool result = valueIn.ContainsAny("this", "that");
				}
				catch (NullReferenceException ex)
				{
					hasThrown = true;
				}
				Assert.IsTrue(hasThrown);
			}

			[TestMethod]
			public void ThrowsOnNullValue()
			{
				bool hasThrown = false;

				try
				{
					string valueIn = "test this string";
					bool result = valueIn.ContainsAny(null);
				}
				catch (ArgumentNullException ex)
				{
					hasThrown = true;
				}
				Assert.IsTrue(hasThrown);
			}

			[TestMethod]
			public void ThrowsOnNoValue()
			{
				bool hasThrown = false;

				try
				{
					string valueIn = "test this string";
					bool result = valueIn.ContainsAny();
				}
				catch (ArgumentNullException ex)
				{
					hasThrown = true;
				}
				Assert.IsTrue(hasThrown);
			}

			[TestMethod]
			public void ReturnsTrueOnMatch()
			{
				string valueIn = "test this string";
				bool result = valueIn.ContainsAny("this", "that");
				Assert.IsTrue(result);
			}

			[TestMethod]
			public void ReturnsFalseOnNoMatch()
			{
				string valueIn = "test this string";
				bool result = valueIn.ContainsAny("that", "there");
				Assert.IsFalse(result);
			}
		
		}

		[TestClass]
		public class ReplaceFirst : StringExtensionsTest
		{
			[TestMethod]
			public void ThrowsOnNullReference()
			{
				bool hasThrown = false;

				try
				{
					string valueIn = null;
					string valueOut = valueIn.ReplaceFirst("this", "that");
				}
				catch (NullReferenceException ex)
				{
					hasThrown = true;
				}
				Assert.IsTrue(hasThrown);
			}

			[TestMethod]
			public void ThrowsOnNullSearch()
			{
				bool hasThrown = false;

				try
				{
					string valueIn = "test this string";
					string valueOut = valueIn.ReplaceFirst(null, "that");
				}
				catch (ArgumentNullException ex)
				{
					hasThrown = true;
				}
				Assert.IsTrue(hasThrown);
			}

			[TestMethod]
			public void TreatsNullValueAsEmptyString()
			{
				string valueIn = "test this string";
				string valueOut1 = valueIn.ReplaceFirst("this", null);
				string valueOut2 = valueIn.ReplaceFirst("this", "");

				Assert.AreEqual<string>(valueOut1, valueOut2);
			}

			[TestMethod]
			public void ReturnsStringOnNoMatch()
			{
				string valueIn = "test this string";
				string valueOut = valueIn.ReplaceFirst("a", "b");
				Assert.AreEqual<string>(valueIn, valueOut);
			}

			[TestMethod]
			public void ReplacesOnce()
			{
				string valueIn = "test this string";
				// valueOut is 1 char longer for each replace that is done.
				string valueOut = valueIn.ReplaceFirst("i", "ii");
				Assert.AreEqual<int>(valueIn.Length, valueOut.Length - 1);
			}


		}

	}
}
