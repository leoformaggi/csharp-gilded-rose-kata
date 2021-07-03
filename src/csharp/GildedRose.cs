using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;

        private readonly ItemMapper _itemMapper;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
            _itemMapper = ItemMapper.Instance;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                IAdvanceableDay customizedType = _itemMapper.GetCustomizedType(item);
                customizedType.AdvanceDay(item);
            }
        }
    }
}
