namespace csharp
{
    public class Sulfuras : Item, IAdvanceableDayItem
    {
        public const string NAME = "Sulfuras, Hand of Ragnaros";
        private const int IMMUTABLE_VALUE = 80;

        public Sulfuras()
        {
            Name = NAME;
            Quality = IMMUTABLE_VALUE;
        }

        public void AdvanceDay()
        { 
            // Sulfuras does not change SellIn and Quality
        }
    }
}
