namespace csharp
{
    public class GenericItem : Item, IAdvanceableDayItem
    {
        public GenericItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public void AdvanceDay()
        {
            SellIn--;

            if (Quality == 0)
                return;

            if (Quality > 0)
                Quality--;

            if (SellIn < 0 && Quality > 0)
                Quality--;
        }
    }
}
