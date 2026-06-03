using System.Collections.Generic;

namespace GildedTros.App
{
    public class InventoryManager
    {
        IList<Item> Items;

        public InventoryManager(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var strategy = MatchStrategyByName(item.Name);
                strategy?.Update(item);
            }
        }

        IItemUpdateStrategy MatchStrategyByName(string name)
        {
			if (name == "B-DAWG Keychain")
			{
				return null;
			}

			switch (name)
			{
				case "Good Wine":
					return new GoodWineStrategy();
				case "Backstage passes for Re:factor":
				case "Backstage passes for HAXX":
					return new BackStagePassesStrategy();
				case "Duplicate Code":
				case "Long Methods":
				case "Ugly Variable Names":
					return new SmellyItemsStrategy();
				default:
					return new NormalItemStrategy();
			}
        }
    }
}
