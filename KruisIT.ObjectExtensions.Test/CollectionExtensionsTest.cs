using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KruisIT.Object.Extensions;

namespace KruisIT.Object.Extensions.Test
{
	[TestClass]
	public class CollectionExtensionsTest
	{
		[TestClass]
		public class TakeLast : CollectionExtensionsTest
		{
			[TestMethod]
			public void ThrowsOnNullReference()
			{
				bool hasThrown = false;

				try
				{
					List<int> valueIn = null;
					IEnumerable<int> result = valueIn.TakeLast(1);
				}
				catch (NullReferenceException ex)
				{
					hasThrown = true;
				}
				Assert.IsTrue(hasThrown);
			}

			[TestMethod]
			public void ReturnsZeroItemsOnZeroValue()
			{
				int nrToTake = 0;

				List<int> valueIn = new List<int>() { 1, 2, 3, 4, 5 };
				List<int> result = valueIn.TakeLast(nrToTake).ToList();
				Assert.AreEqual<int>(nrToTake, result.Count);
			}

			[TestMethod]
			public void ReturnsZeroItemsOnNegativeValue()
			{
				int nrToTake = -1;

				List<int> valueIn = new List<int>() { 1, 2, 3, 4, 5 };
				List<int> result = valueIn.TakeLast(nrToTake).ToList();
				Assert.AreEqual<int>(0, result.Count);
			}

			[TestMethod]
			public void ReturnsOneItemOnOneValue()
			{
				int nrToTake = 1;

				List<int> valueIn = new List<int>() { 1, 2, 3, 4, 5 };
				List<int> result = valueIn.TakeLast(nrToTake).ToList();
				Assert.AreEqual<int>(nrToTake, result.Count);
			}

			[TestMethod]
			public void ReturnsAllItemsOnTooHighValue()
			{
				int nrToTake = 10;

				List<int> valueIn = new List<int>() { 1, 2, 3, 4, 5 };
				List<int> result = valueIn.TakeLast(nrToTake).ToList();
				Assert.AreEqual<int>(valueIn.Count, result.Count);
			}

		}

	}
}
