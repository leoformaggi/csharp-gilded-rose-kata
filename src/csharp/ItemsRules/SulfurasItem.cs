namespace csharp
{
    [SpecializedItem("Sulfuras, Hand of Ragnaros")]
    public class SulfurasItem : IAdvanceableDay
    {
        public void AdvanceDay(Item item)
        {
            // Sulfuras does not change SellIn and Quality
        }
    }
}
