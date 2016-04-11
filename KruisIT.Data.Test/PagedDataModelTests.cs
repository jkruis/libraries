using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KruisIT.Data.Test
{
	[TestClass]
	public class PagedDataModelTests
	{
		public static List<string> CreateTestData(int length)
		{
			if (26 < length)
			{
				throw new ArgumentOutOfRangeException("Please check what happens with CreateTestData when length > 26.");
			}

			List<string> items = new List<string>();
			int asciiStart = Convert.ToInt32('a');
			
			for (int counter = 0; counter < length; counter++) {
				items.Add(Convert.ToChar(asciiStart + counter).ToString());
			}

			return items;
		}

		[TestMethod]
		public void TestDataReturnsCorrectLength()
		{
			const int LIST_LENGTH = 15;
			List<string> items = CreateTestData(LIST_LENGTH);
			Assert.AreEqual(LIST_LENGTH, items.Count);
		}

		[TestClass]
		public class Constructor
		{
			const int PAGE_SIZE = 10;

			[TestMethod]
			public void ReturnsModelOnNullData()
			{
				global::KruisIT.Data.PagedDataModel<string> model = new KruisIT.Data.PagedDataModel<string>(null, PAGE_SIZE, 1);
				Assert.IsNotNull(model);
			}

			[TestMethod]
			public void ReturnsModelWithDataPropertyNullOnNullData()
			{
				global::KruisIT.Data.PagedDataModel<string> model = new KruisIT.Data.PagedDataModel<string>(null, PAGE_SIZE, 1);
				Assert.IsNull(model.Data);
			}

			[TestMethod]
			public void ReturnsCorrectTotalCount()
			{
				const int LIST_LENGTH = 20;
				List<string> items = CreateTestData(LIST_LENGTH);

				global::KruisIT.Data.PagedDataModel<string> model = new KruisIT.Data.PagedDataModel<string>(items, PAGE_SIZE, 1);

				Assert.AreEqual(LIST_LENGTH, model.PagerInfo.ItemCount);
			}

			[TestMethod]
			public void ReturnsCorrectPageCount()
			{
				const int LIST_LENGTH = 21;
				List<string> items = CreateTestData(LIST_LENGTH);

				global::KruisIT.Data.PagedDataModel<string> model = new KruisIT.Data.PagedDataModel<string>(items, PAGE_SIZE, 1);

				Assert.AreEqual(3, model.PagerInfo.PageCount);
			}

			[TestMethod]
			public void ReturnsCorrectPageSizeOnFewItems()
			{
				int listLength = PAGE_SIZE - 1;
				List<string> items = CreateTestData(listLength);

				global::KruisIT.Data.PagedDataModel<string> model = new KruisIT.Data.PagedDataModel<string>(items, PAGE_SIZE, 1);

				Assert.AreEqual(listLength, model.Data.Count);
			}

			[TestMethod]
			public void ReturnsCorrectPageSizeOnManyItems()
			{
				int listLength = PAGE_SIZE + 1;
				List<string> items = CreateTestData(listLength);

				global::KruisIT.Data.PagedDataModel<string> model = new KruisIT.Data.PagedDataModel<string>(items, PAGE_SIZE, 1);

				Assert.AreEqual(PAGE_SIZE, model.Data.Count);
			}

			[TestMethod]
			public void ReturnsCorrectPageSizeOnLastPage()
			{
				int listLength = PAGE_SIZE + 1;
				List<string> items = CreateTestData(listLength);

				global::KruisIT.Data.PagedDataModel<string> model = new KruisIT.Data.PagedDataModel<string>(items, PAGE_SIZE, 2);

				Assert.AreEqual(1, model.Data.Count);
			}


		}


	}

}
