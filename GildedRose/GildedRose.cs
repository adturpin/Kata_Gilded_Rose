using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        private const string AGE_BRIE_NAME = "Aged Brie";
        private const string BACK_STACGE_PASSE_NAME = "Backstage passes to a TAFKAL80ETC concert";
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

                if (item.Name == BACK_STACGE_PASSE_NAME)
                {
                    UpdateBackStagePasse(item);
                    continue;
                }

                if (item.Name == AGE_BRIE_NAME)
                {
                    UpdateAgeBrie(item);
                    continue;
                }

                UpdateNormalItem(item);
            }
        }

        private static void UpdateAgeBrie(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = UpgradeQuality(item);
                if (item.SellIn < 0)
                    item.Quality = UpgradeQuality(item);
            }
        }

        private static void UpdateBackStagePasse(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = UpgradeQuality(item);
                if (item.SellIn < 10)
                    DownGradeUnitlFifty(item);

                if (item.SellIn < 5)
                    DownGradeUnitlFifty(item);
            }

            if (item.SellIn < 0)
                item.Quality = ResetQuality();
        }

        private static void UpdateNormalItem(Item item)
        {
            if (item.SellIn < 0)
                item.Quality = DowngradePositiveQuality(item);

            item.Quality = DowngradePositiveQuality(item);
        }

        private static void DownGradeUnitlFifty(Item item)
        {
            if (item.Quality < 50)
                item.Quality = UpgradeQuality(item);
        }

        private static int DowngradePositiveQuality(Item item)
        {
            if (item.Quality > 0)
                return item.Quality - 1;
            return item.Quality;
        }

        private static int UpgradeQuality(Item item)
        {
            return item.Quality + 1;
        }

        private static int ResetQuality()
        {
            return 0;
        }
    }
}