using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using FluentAssertions;

namespace GildedRose.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var goldenMasterItems =ItemProviderTest.GetItems();
            var goldenMaster = new GildedRoseGoldenMaster(goldenMasterItems);
            var items =ItemProviderTest.GetItems();
            var app = new GildedRose(items);
            for (var i = 0; i < 100; i++)
            {
                goldenMaster.UpdateQuality();
                app.UpdateQuality();

                goldenMasterItems.Select(x => x.Quality)
                    .Should().ContainInOrder(items.Select(x => x.Quality));
                goldenMasterItems.Select(x => x.SellIn)
                    .Should().ContainInOrder(items.Select(x => x.SellIn));
            }

        }
    }
}
