namespace csharp
{
    public class SulfurasItemRules : IAdvanceableDay
    {
        public const string NAME = "Sulfuras, Hand of Ragnaros";

        public void AdvanceDay(Item item)
        { 
            // Sulfuras does not change SellIn and Quality
        }
    }
}
