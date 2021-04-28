using System;
using System.Collections.Generic;
using System.IO;
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
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);

            Dictionary<string,string> COLLECTION = new Dictionary<string, string>();
            foreach (KeyValuePair<string,string> VARIABLE in COLLECTION)
            {
                
            }
        }

        //[TestMethod]
        //public void ThirtyDays()
        //{
        //    StringBuilder fakeoutput = new StringBuilder();
        //    Console.SetOut(new StringWriter(fakeoutput));
        //    Console.SetIn(new StringReader("a\n"));
        //    Program.Main(new string[] { });
        //    var output = fakeoutput.ToString();
        //    Approvals.Verify(output);
        //}
    }
}
