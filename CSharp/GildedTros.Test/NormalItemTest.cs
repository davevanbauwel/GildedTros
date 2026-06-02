using GildedTros.App;
using Xunit;

namespace GildedTros.Test
{
    public class NormalItemTest
	{
		[Fact]
		public void TestQuality_DegradeByOneEachDay()
		{
			var items = new List<Item>
			{
				new Item { Name = "Ring of Cleansening Code", SellIn = 10, Quality = 20 }
			};
			var app = new InventoryManager(items);

			app.UpdateQuality();

			Assert.Equal(19, items[0].Quality);
			Assert.Equal(9, items[0].SellIn);
		}

		[Fact]
		public void TestQuality_DegradeTwiceAsFastAfterSellByDay()
		{
			var items = new List<Item>
			{
				new Item { Name = "Ring of Cleansening Code", SellIn = 0, Quality = 20 }
			};
			var app = new InventoryManager(items);

			app.UpdateQuality();

			Assert.Equal(18, items[0].Quality);
			Assert.Equal(-1, items[0].SellIn);
		}

		[Fact]
		public void TestQuality_NeverNegative()
		{
			var items = new List<Item>
			{
				new Item { Name = "Ring of Cleansening Code", SellIn = 10, Quality = 0 }
			};
			var app = new InventoryManager(items);

			app.UpdateQuality();

			Assert.Equal(0, items[0].Quality);
			Assert.Equal(9, items[0].SellIn);
		}
	}
}
