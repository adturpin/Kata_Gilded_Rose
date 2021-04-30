using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        private const string BACKSTAGE_PASS_NAME = "Backstage passes to a TAFKAL80ETC concert";
        private const string AGE_BRIE_NAME = "Aged Brie";
        private const string SULFURAS_NAME = "Sulfuras, Hand of Ragnaros";
        private readonly IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (item.Name == SULFURAS_NAME)
                    continue;

                item.SellIn = item.SellIn - 1;
                
                if (item.Name == AGE_BRIE_NAME)
                {
                    UpdateAgeBrieItem(item);
                }
                else if (item.Name == BACKSTAGE_PASS_NAME)
                {
                    UpdateBackStagePassItem(item);
                }
                else
                {
                    UpdateNormalItem(item);
                }
             
            }
        }

        private static void UpdateNormalItem(Item item)
        {
            if (item.Quality > 0)
                item.Quality = DecreaseQuality(item);
            if (item.SellIn < 0)
            {
                if (item.Quality > 0)
                    item.Quality = DecreaseQuality(item);
            }
        }

        private static void UpdateBackStagePassItem(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = IncreaseQuality(item);
                if (item.SellIn < 10)
                    IncreaseQualityUntilFifty(item);

                if (item.SellIn < 5)
                    IncreaseQualityUntilFifty(item);
            }

            if (item.SellIn < 0)
            {
                item.Quality = ResetQuality();
            }
        }

        private static void UpdateAgeBrieItem(Item item)
        {
            IncreaseQualityUntilFifty(item);
            if (item.SellIn < 0)
            {
                IncreaseQualityUntilFifty(item);
            }
        }

        private static void IncreaseQualityUntilFifty(Item item)
        {
            if (item.Quality < 50)
                item.Quality = IncreaseQuality(item);
        }

        private static int DecreaseQuality(Item item)
        {
            return item.Quality - 1;
        }

        private static int ResetQuality()
        {
            return 0;
        }

        private static int IncreaseQuality(Item item)
        {
            return item.Quality + 1;
        }
    }
}