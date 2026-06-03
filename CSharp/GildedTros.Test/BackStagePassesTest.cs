using GildedTros.App;
using Xunit;

namespace GildedTros.Test
{
    public class BackStagePassesTest
	{
		[Fact]
		public void TestQuality_IncreasesByOneWhenMoreThan10DaysBeforeSellDay()
		{
			var items = new List<Item>
			{
				new Item { Name = "Backstage passes for Re:factor", SellIn = 15, Quality = 20 }
			};
			var app = new InventoryManager(items);

			app.UpdateQuality();

			Assert.Equal(21, items[0].Quality);
			Assert.Equal(14, items[0].SellIn);
		}

		[Fact]
		public void TestQuality_IncreasesByTwoWhen_10_To_5_DaysBeforeSellByDay()
		{
			var items = new List<Item>
			{
				new Item { Name = "Backstage passes for Re:factor", SellIn = 9, Quality = 20 }
			};
			var app = new InventoryManager(items);

			app.UpdateQuality();

			Assert.Equal(22, items[0].Quality);
			Assert.Equal(8, items[0].SellIn);
		}

		[Fact]
		public void TestQuality_IncreasesByThreeWhen_5_To_0_DaysBeforeSellByDay()
		{
			var items = new List<Item>
			{
				new Item { Name = "Backstage passes for Re:factor", SellIn = 4, Quality = 20 }
			};
			var app = new InventoryManager(items);

			app.UpdateQuality();

			Assert.Equal(23, items[0].Quality);
			Assert.Equal(3, items[0].SellIn);
		}

		[Fact]
		public void TestQuality_NeverMoreThanMaximum()
		{
			var items = new List<Item>
			{
				new Item { Name = "Backstage passes for Re:factor", SellIn = 4, Quality = 49 }
			};
			var app = new InventoryManager(items);

			app.UpdateQuality();

			Assert.Equal(50, items[0].Quality);
			Assert.Equal(3, items[0].SellIn);
		}

		[Fact]
		public void TestQuality_ZeroAfterSellByDay()
		{
			var items = new List<Item>
			{
				new Item { Name = "Backstage passes for Re:factor", SellIn = 0, Quality = 49 }
			};
			var app = new InventoryManager(items);

			app.UpdateQuality();

			Assert.Equal(0, items[0].Quality);
			Assert.Equal(-1, items[0].SellIn);
		}
	}
}
