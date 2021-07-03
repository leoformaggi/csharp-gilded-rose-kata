namespace csharp
{
    public class AgedBrie : Item, IAdvanceableDayItem
    {
        public const string NAME = "Aged Brie";

        public AgedBrie(int sellIn, int quality)
        {
            Name = NAME;
            SellIn = sellIn;
            Quality = quality;
        }

        public void AdvanceDay()
        {
            SellIn--;

            if (Quality < 50)
                Quality++;

            if (SellIn < 0 && Quality < 50)
                Quality++;
        }
    }
}
