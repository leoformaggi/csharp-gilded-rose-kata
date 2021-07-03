using NUnit.Framework;
using System.Collections.Generic;

namespace csharp.Tests
{
    [TestFixture]
    public class GenericItemsTests
    {
        [Test]
        public void Generic_items_quality_should_not_be_negative()
        {
            var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 2 } };

            var app = new GildedRose(items);

            for (int i = 0; i < 4; i++)
                app.UpdateQuality();

            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void Generic_items_quality_should_decrease_by_1_everyday_when_SellIn_is_positive()
        {
            int sellIn = 10;
            int quality = 10;

            Item genericItem = new Item { Name = "foo", SellIn = sellIn, Quality = quality };
            var items = new List<Item> { genericItem };

            var app = new GildedRose(items);

            int day = 1;
            while (genericItem.SellIn > 0)
            {
                app.UpdateQuality();

                Assert.AreEqual(quality - day, genericItem.Quality);
                day++;
            }
        }

        [Test]
        public void Generic_items_quality_should_decrease_by_2_everyday_when_SellIn_is_negative()
        {
            int sellIn = 0;
            int quality = 9;

            Item genericItem = new Item { Name = "foo", SellIn = sellIn, Quality = quality };
            var items = new List<Item> { genericItem };

            var app = new GildedRose(items);

            int day = 1;
            while (genericItem.Quality > 1)
            {
                app.UpdateQuality();

                Assert.AreEqual(quality - (2 * day), genericItem.Quality);
                day++;
            }
        }
    }

}
