namespace csharp
{
    [SpecializedItem("Conjured Mana Cake")]
    public class ConjuredItem : IAdvanceableDay
    {
        public void AdvanceDay(Item item)
        {
            item.SellIn--;

            if (item.Quality == 0)
                return;

            if (item.Quality > 0)
                item.Quality -= 2;

            if (item.SellIn < 0 && item.Quality > 0)
                item.Quality -= 2;

            if (item.Quality < 0)
                item.Quality = 0;
        }
    }
}
