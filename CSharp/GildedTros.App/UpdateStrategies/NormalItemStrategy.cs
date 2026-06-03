namespace GildedTros.App
{
    public class NormalItemStrategy : IItemUpdateStrategy
    {
        int DecreaseQualityBeforeSellDay => 1;
        int DecreaseQualityAfterSellDay => 2;  

        public void Update(Item item)
        {
            item.SellIn--;

            if (item.Quality == 0)
            {
                return;
            }

            if (item.SellIn < 0)
            {
                item.Quality -= DecreaseQualityAfterSellDay;
			}
            else
            {
                item.Quality -= DecreaseQualityBeforeSellDay;
            }
        }
    }
}
