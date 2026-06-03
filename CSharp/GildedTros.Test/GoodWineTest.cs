using GildedTros.App;
using Xunit;

namespace GildedTros.Test
{
    public class GoodWineTest
	{
		[Fact]
		public void TestQuality_IncreasesByOneEachDay()
		{
			var items = new List<Item>
			{
				new Item { Name = "Good Wine", SellIn = 2, Quality = 0 }
			};
			var app = new InventoryManager(items);

			app.UpdateQuality();

			Assert.Equal(1, items[0].Quality);
			Assert.Equal(1, items[0].SellIn);
		}

		[Fact]
		public void TestQuality_IncreasesByTwoAfterSellByDay()
		{
			var items = new List<Item>
			{
				new Item { Name = "Good Wine", SellIn = 0, Quality = 0 }
			};
			var app = new InventoryManager(items);

			app.UpdateQuality();

			Assert.Equal(2, items[0].Quality);
			Assert.Equal(-1, items[0].SellIn);
		}

		[Fact]
		public void TestQuality_NeverMoreThanMaximum()
		{
			var items = new List<Item>
			{
				new Item { Name = "Good Wine", SellIn = 2, Quality = 50 }
			};
			var app = new InventoryManager(items);

			app.UpdateQuality();

			Assert.Equal(50, items[0].Quality);
			Assert.Equal(1, items[0].SellIn);
		}
	}
}
