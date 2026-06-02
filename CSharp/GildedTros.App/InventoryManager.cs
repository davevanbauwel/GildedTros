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

        private IItemUpdateStrategy MatchStrategyByName(string name)
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
				default:
					return new NormalItemStrategy();
			}
        }

        /*public void UpdateQuality()
			{

				for (var i = 0; i < Items.Count; i++)
				{
					if (Items[i].Name != "Good Wine" 
						&& Items[i].Name != "Backstage passes for Re:factor"
						&& Items[i].Name != "Backstage passes for HAXX")
					{
						if (Items[i].Quality > 0)
						{
							if (Items[i].Name != "B-DAWG Keychain")
							{
								Items[i].Quality = Items[i].Quality - 1;
							}
						}
					}
					else
					{
						if (Items[i].Quality < 50)
						{
							Items[i].Quality = Items[i].Quality + 1;

							if (Items[i].Name == "Backstage passes for Re:factor"
							|| Items[i].Name == "Backstage passes for HAXX")
							{
								if (Items[i].SellIn < 11)
								{
									if (Items[i].Quality < 50)
									{
										Items[i].Quality = Items[i].Quality + 1;
									}
								}

								if (Items[i].SellIn < 6)
								{
									if (Items[i].Quality < 50)
									{
										Items[i].Quality = Items[i].Quality + 1;
									}
								}
							}
						}
					}

					if (Items[i].Name != "B-DAWG Keychain")
					{
						Items[i].SellIn = Items[i].SellIn - 1;
					}

					if (Items[i].SellIn < 0)
					{
						if (Items[i].Name != "Good Wine")
						{
							if (Items[i].Name != "Backstage passes for Re:factor"
								&& Items[i].Name != "Backstage passes for HAXX")
							{
								if (Items[i].Quality > 0)
								{
									if (Items[i].Name != "B-DAWG Keychain")
									{
										Items[i].Quality = Items[i].Quality - 1;
									}
								}
							}
							else
							{
								Items[i].Quality = Items[i].Quality - Items[i].Quality;
							}
						}
						else
						{
							if (Items[i].Quality < 50)
							{
								Items[i].Quality = Items[i].Quality + 1;
							}
						}
					}
				}
			}*/
    }
}
