namespace csharp
{
    public class BackstagePasses : Item, IAdvanceableDayItem
    {
        public const string NAME = "Backstage passes to a TAFKAL80ETC concert";

        public BackstagePasses(int sellIn, int quality)
        {
            Name = NAME;
            SellIn = sellIn;
            Quality = quality;
        }

        public void AdvanceDay()
        {
            if (Quality < 50)
            {
                Quality++;

                if (SellIn < 11 && Quality < 50)
                    Quality++;

                if (SellIn < 6 && Quality < 50)
                    Quality++;
            }

            SellIn--;

            if (SellIn < 0)
                Quality = 0;
        }
    }
}
