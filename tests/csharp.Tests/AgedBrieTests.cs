using NUnit.Framework;
using System.Collections.Generic;

namespace csharp.Tests
{
    [TestFixture]
    public class AgedBrieTests
    {
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
        public void Aged_brie_quality_should_raise_everyday_specialized()
        {
            var agedBrie = new AgedBrie(10, 0);

            Assert.AreEqual(0, agedBrie.Quality);
            for (int i = 1; i <= 10; i++)
            {
                agedBrie.AdvanceDay();

                if (agedBrie.SellIn > 0)
                    Assert.AreEqual(i, agedBrie.Quality);
            }
        }

        [Test]
        public void Aged_brie_quality_should_not_be_higher_than_50_specialized()
        {
            var item = new AgedBrie(10, 49);

            for (int i = 0; i < 3; i++)
                item.AdvanceDay();

            Assert.AreEqual(50, item.Quality);
        }
    }

}
