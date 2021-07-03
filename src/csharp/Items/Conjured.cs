namespace csharp
{
    public class Conjured : IAdvanceableDay
    {
        public const string NAME = "Conjured Mana Cake";

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
