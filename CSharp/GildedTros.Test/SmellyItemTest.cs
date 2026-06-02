using GildedTros.App;
using Xunit;

namespace GildedTros.Test
{
    public class SmellyItemTest
	{
		[Fact]
		public void TestQuality_DegradeTwiceAsFastBeforeSellByDay()
		{
			var items = new List<Item>
			{
				new Item { Name = "Duplicate Code", SellIn = 4, Quality = 5 }
			};
			var app = new InventoryManager(items);

			app.UpdateQuality();

			Assert.Equal(3, items[0].Quality);
			Assert.Equal(3, items[0].SellIn);
		}

		[Fact]
		public void TestQuality_DegradeFourTimesAsFastBeforeSellByDay()
		{
			var items = new List<Item>
			{
				new Item { Name = "Duplicate Code", SellIn = 4, Quality = 5 }
			};
			var app = new InventoryManager(items);

			app.UpdateQuality();

			Assert.Equal(1, items[0].Quality);
			Assert.Equal(3, items[0].SellIn);
		}

		[Fact]
		public void TestQuality_NeverNegative()
		{
			var items = new List<Item>
			{
				new Item { Name = "Duplicate Code", SellIn = 4, Quality = 1 }
			};
			var app = new InventoryManager(items);

			app.UpdateQuality();

			Assert.Equal(0, items[0].Quality);
			Assert.Equal(3, items[0].SellIn);
		}
	}
}
