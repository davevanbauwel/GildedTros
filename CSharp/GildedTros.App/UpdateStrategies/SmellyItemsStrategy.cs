using System;

namespace GildedTros.App
{
    public class SmellyItemsStrategy : IItemUpdateStrategy
    {
		int DecreaseQualityBeforeSellDay => 2;
		int DecreaseQualityAfterSellDay => 4;

		public void Update(Item item)
		{
			item.SellIn--;

			if (item.SellIn < 0)
			{
				item.Quality = Math.Max(item.Quality - DecreaseQualityAfterSellDay, 0);
			}
			else
			{
				item.Quality = Math.Max(item.Quality - DecreaseQualityBeforeSellDay, 0);
			}
		}
	}
}
