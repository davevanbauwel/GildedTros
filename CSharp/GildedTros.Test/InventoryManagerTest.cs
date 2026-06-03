using GildedTros.App;
using Xunit;

namespace GildedTros.Test
{
    public class InventoryManagerTest
    {
        [Fact]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
			InventoryManager app = new InventoryManager(Items);
            app.UpdateQuality();
            Assert.Equal("foo", Items[0].Name);
        }
    }
}