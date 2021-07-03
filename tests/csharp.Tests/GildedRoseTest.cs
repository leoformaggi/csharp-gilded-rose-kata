using NUnit.Framework;
using System.Collections.Generic;

namespace csharp.Tests
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test(Description = "This test is dependent on Aged Brie item tests. May be fragile.")]
        public void Items_quality_should_not_be_higher_than_50()
        {
            // using item that grows quality
            Item genericItem = new Item { Name = "Aged Brie", SellIn = 10, Quality = 49 };
            var items = new List<Item> { genericItem };

            var app = new GildedRose(items);

            for (int i = 0; i < 3; i++)
                app.UpdateQuality();

            Assert.AreEqual(50, genericItem.Quality);
        }
    }
}
