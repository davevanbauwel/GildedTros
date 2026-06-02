using System;

namespace GildedTros.App
{
    public class BackStagePassesStrategy : IItemUpdateStrategy
    {
		int IncreaseQualityMoreThan10DaysBeforeSellDay => 1;
		int IncreaseQualityMoreThan5DaysBeforeSellDay => 2;
		int IncreaseQualityLessThan5DaysBeforeSellDay => 3;
		int MaximumQuality => 50;

		public void Update(Item item)
		{
			item.SellIn--;

			if (item.SellIn < 0)
			{
				item.Quality = 0;
			}
			else if (item.SellIn > 10)
			{
				item.Quality = Math.Min(item.Quality + IncreaseQualityMoreThan10DaysBeforeSellDay, MaximumQuality);
			}
			else if (item.SellIn > 5)
			{
				item.Quality = Math.Min(item.Quality + IncreaseQualityMoreThan5DaysBeforeSellDay, MaximumQuality);
			}
			else
			{
				item.Quality = Math.Min(item.Quality + IncreaseQualityLessThan5DaysBeforeSellDay, MaximumQuality);
			}
		}
	}
}
