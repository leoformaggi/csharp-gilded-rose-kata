using NUnit.Framework;
using System.Collections.Generic;

namespace csharp.Tests
{
    [TestFixture]
    public class SulfurasTests
    {
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
    }
}