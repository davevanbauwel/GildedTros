namespace GildedTros.App
{
    public class NormalItemStrategy : IItemUpdateStrategy
    {
        int IncreaseQualityBeforeSellDay => 1;
        int IncreaseQualityAfterSellDay => 2;  

        public void Update(Item item)
        {
            item.SellIn--;

            if (item.Quality == 0)
            {
                return;
            }

            if (item.SellIn < 0)
            {
                item.Quality -= IncreaseQualityAfterSellDay;
			}
            else
            {
                item.Quality -= IncreaseQualityBeforeSellDay;
            }
        }
    }
}
