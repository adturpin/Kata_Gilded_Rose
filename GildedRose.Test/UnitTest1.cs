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
        public void TestMethod1()
        {
            var refactoItems = ItemProviderTest.GetItems();
            var gildedRose = new GildedRose(refactoItems);
            var masterItems = ItemProviderTest.GetItems();
            var goldenMaster = new GildedRoseGoldenMaster(masterItems);
            var iterator =Enumerable.Range(0,100);
            foreach (var i in iterator)
            {
                gildedRose.UpdateQuality();
                goldenMaster.UpdateQuality();
                CollectionAssert.AreEqual(
                    masterItems.Select(x => x.Quality).ToArray(),
                    refactoItems.Select(x => x.Quality).ToArray());
                CollectionAssert.AreEqual(
                    masterItems.Select(x => x.SellIn).ToArray(), 
                    refactoItems.Select(x => x.SellIn).ToArray());
            }


        }
    }
}
