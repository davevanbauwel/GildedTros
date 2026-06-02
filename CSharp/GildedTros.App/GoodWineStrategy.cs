using System;

namespace GildedTros.App
{
    public class GoodWineStrategy : IItemUpdateStrategy
    {
        int IncreaseQualityBeforeSellDay => 1;
        int IncreaseQualityAfterSellDay => 2;

        int MaximumQuality => 50;

        public void Update(Item item)
        {
            item.SellIn--;

            if (item.SellIn < 0)
            {
                item.Quality = Math.Min(item.Quality + IncreaseQualityAfterSellDay, MaximumQuality);
			}
            else
			{
				item.Quality = Math.Min(item.Quality + IncreaseQualityBeforeSellDay, MaximumQuality);
            }
        }
    }
}
