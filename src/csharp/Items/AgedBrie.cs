namespace csharp
{
    public class AgedBrie : IAdvanceableDay
    {
        public const string NAME = "Aged Brie";

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
