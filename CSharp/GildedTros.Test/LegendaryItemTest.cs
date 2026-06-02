using GildedTros.App;
using Xunit;

namespace GildedTros.Test
{
    public class LegendaryItemTest
	{
		[Fact]
		public void TestQualityAndSellIn_NeverChanges()
		{
			var items = new List<Item>
			{
				new Item { Name = "B-DAWG Keychain", SellIn = 0, Quality = 80 }
			};
			var app = new InventoryManager(items);

			app.UpdateQuality();

			Assert.Equal(80, items[0].Quality);
			Assert.Equal(0, items[0].SellIn);
		}
	}
}
