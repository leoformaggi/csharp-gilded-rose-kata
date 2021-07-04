namespace csharp
{
    public class GenericItem : IAdvanceableDay
    {
        public void AdvanceDay(Item item)
        {
            item.SellIn--;

            if (item.Quality == 0)
                return;

            if (item.Quality > 0)
                item.Quality--;

            if (item.SellIn < 0 && item.Quality > 0)
                item.Quality--;
        }
    }
}
