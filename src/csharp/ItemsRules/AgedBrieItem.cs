namespace csharp
{
    [SpecializedItem("Aged Brie")]
    public class AgedBrieItem : IAdvanceableDay
    {
        public void AdvanceDay(Item item)
        {
            item.SellIn--;

            if (item.Quality < 50)
                item.Quality++;

            if (item.SellIn < 0 && item.Quality < 50)
                item.Quality++;
        }
    }
}
