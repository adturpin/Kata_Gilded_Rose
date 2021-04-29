using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GildedRose;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace GildedRose.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GoldenMasterTest()
        {
            var goldenItems = ItemProviderTest.GetItems();
            var refactoredItems = ItemProviderTest.GetItems();

            var goldenMasterApp = new GildedRose(goldenItems);
            var refactorApp = new GildedRoseRefactor(refactoredItems);
            for (int i = 0; i < 100; i++)
            {
                goldenMasterApp.UpdateQuality();
                refactorApp.UpdateQuality();
                CollectionAssert.AreEquivalent(goldenItems.Select(x => x.Quality).ToArray(),
                    refactoredItems.Select(x => x.Quality).ToArray());
                CollectionAssert.AreEquivalent(goldenItems.Select(x => x.SellIn).ToArray(),
                    refactoredItems.Select(x => x.SellIn).ToArray());
            }
        }
    }
}