using NUnit.Framework;
using System.Collections.Generic;

namespace csharp.Tests
{
    [TestFixture]
    public class ConjuredItemsTests
    {
        [Ignore("Conjured items are not supported yet")]
        public void Conjured_items_quality_should_decrease_by_2_everyday_when_SellIn_is_positive()
        {
            int sellIn = 5;
            int quality = 10;

            var conjuredItem = new Item { Name = "Conjured Mana Cake", SellIn = sellIn, Quality = quality };

            var items = new List<Item> { conjuredItem };

            var app = new GildedRose(items);

            int day = 1;
            while (conjuredItem.SellIn > 0)
            {
                app.UpdateQuality();

                Assert.AreEqual(quality - (day * 2), conjuredItem.Quality);
                day++;
            }
        }

        [Ignore("Conjured items are not supported yet")]
        public void Conjured_items_quality_should_decrease_by_4_everyday_when_SellIn_is_negative()
        {
            int sellIn = 0;
            int quality = 24;

            var conjuredItem = new Item { Name = "Conjured Mana Cake", SellIn = sellIn, Quality = quality };

            var items = new List<Item> { conjuredItem };

            var app = new GildedRose(items);

            int day = 1;
            while (conjuredItem.Quality > 3)
            {
                app.UpdateQuality();

                Assert.AreEqual(quality - (day * 4), conjuredItem.Quality);
                day++;
            }
        }
    }

}
