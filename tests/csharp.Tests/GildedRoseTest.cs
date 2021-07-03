using NUnit.Framework;
using System.Collections.Generic;

namespace csharp.Tests
{
    [TestFixture]
    public class GildedRoseTest
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

        [Test]
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

        [Test]
        public void Aged_brie_quality_should_raise_everyday()
        {
            Item agedBrie = new Item { Name = "Aged Brie", SellIn = 10, Quality = 0 };
            var items = new List<Item> { agedBrie };

            var app = new GildedRose(items);

            Assert.AreEqual(0, agedBrie.Quality);
            for (int i = 1; i <= 10; i++)
            {
                app.UpdateQuality();

                if (agedBrie.SellIn > 0)
                    Assert.AreEqual(i, agedBrie.Quality);
            }
        }

        [Test]
        public void Sulfuras_quality_and_SellIn_should_never_change()
        {
            var sulfuras = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 };
            var items = new List<Item> { sulfuras };

            var app = new GildedRose(items);

            Assert.AreEqual(80, sulfuras.Quality);
            Assert.AreEqual(10, sulfuras.SellIn);

            for (int i = 0; i < 3; i++)
                app.UpdateQuality();

            Assert.AreEqual(80, sulfuras.Quality);
            Assert.AreEqual(10, sulfuras.SellIn);
        }

        [Test]
        public void Backstage_passes_quality_should_increase_everyday_when_SellIn_is_above_10()
        {
            int sellIn = 15;
            var passes = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 0 };
            var items = new List<Item> { passes };

            var app = new GildedRose(items);

            while (passes.SellIn > 10)
            {
                app.UpdateQuality();

                Assert.AreEqual(sellIn - passes.SellIn, passes.Quality);
            }

            app.UpdateQuality();

            Assert.AreNotEqual(sellIn - passes.SellIn, passes.Quality);
        }

        [Test]
        public void Backstage_passes_quality_should_increase_by_2_when_SellIn_is_between_5_and_10()
        {
            int sellIn = 10;
            var passes = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 0 };
            var items = new List<Item> { passes };

            var app = new GildedRose(items);

            while (passes.SellIn > 5)
            {
                app.UpdateQuality();

                Assert.AreEqual((sellIn - passes.SellIn) * 2, passes.Quality);
            }

            app.UpdateQuality();

            Assert.AreNotEqual((sellIn - passes.SellIn) * 2, passes.Quality);
        }

        [Test]
        public void Backstage_passes_quality_should_increase_by_3_when_SellIn_is_less_or_equals_5()
        {
            int sellIn = 5;
            var passes = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 0 };
            var items = new List<Item> { passes };

            var app = new GildedRose(items);

            while (passes.SellIn > 0)
            {
                app.UpdateQuality();

                Assert.AreEqual((sellIn - passes.SellIn) * 3, passes.Quality);
            }

            app.UpdateQuality();

            Assert.AreNotEqual((sellIn - passes.SellIn) * 3, passes.Quality);
        }

        [Test]
        public void Backstage_passes_quality_should_be_zero_when_SellIn_is_less_than_zero()
        {
            var passes = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 };
            var items = new List<Item> { passes };

            Assert.Greater(passes.Quality, 0);

            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(-1, passes.SellIn);
            Assert.AreEqual(0, passes.Quality);
        }

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
