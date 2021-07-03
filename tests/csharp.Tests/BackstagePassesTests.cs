using NUnit.Framework;
using System.Collections.Generic;

namespace csharp.Tests
{
    [TestFixture]
    public class BackstagePassesTests
    {
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


        [Test]
        public void Backstage_passes_quality_should_increase_everyday_when_SellIn_is_above_10_specialized()
        {
            int sellIn = 15;
            var passes = new BackstagePasses(sellIn, 0);

            while (passes.SellIn > 10)
            {
                passes.AdvanceDay();

                Assert.AreEqual(sellIn - passes.SellIn, passes.Quality);
            }

            passes.AdvanceDay();

            Assert.AreNotEqual(sellIn - passes.SellIn, passes.Quality);
        }

        [Test]
        public void Backstage_passes_quality_should_increase_by_2_when_SellIn_is_between_5_and_10_specialized()
        {
            int sellIn = 10;
            var passes = new BackstagePasses(sellIn, 0);

            while (passes.SellIn > 5)
            {
                passes.AdvanceDay();

                Assert.AreEqual((sellIn - passes.SellIn) * 2, passes.Quality);
            }

            passes.AdvanceDay();

            Assert.AreNotEqual((sellIn - passes.SellIn) * 2, passes.Quality);
        }

        [Test]
        public void Backstage_passes_quality_should_increase_by_3_when_SellIn_is_less_or_equals_5_specialized()
        {
            int sellIn = 5;
            var passes = new BackstagePasses(sellIn, 0);

            while (passes.SellIn > 0)
            {
                passes.AdvanceDay();

                Assert.AreEqual((sellIn - passes.SellIn) * 3, passes.Quality);
            }

            passes.AdvanceDay();

            Assert.AreNotEqual((sellIn - passes.SellIn) * 3, passes.Quality);
        }

        [Test]
        public void Backstage_passes_quality_should_be_zero_when_SellIn_is_less_than_zero_specialized()
        {
            var passes = new BackstagePasses(0, 10);

            Assert.Greater(passes.Quality, 0);

            passes.AdvanceDay();

            Assert.AreEqual(-1, passes.SellIn);
            Assert.AreEqual(0, passes.Quality);
        }

        [Test]
        public void Backstage_passes_quality_should_not_be_higher_than_50()
        {
            var passes = new BackstagePasses(10, 49);

            for (int i = 0; i < 3; i++)
                passes.AdvanceDay();

            Assert.AreEqual(50, passes.Quality);
        }
    }
}