using System.Collections.Generic;

namespace csharp
{
    public class ItemMapper
    {
        private const string GENERIC_ITEM_KEY = "default";

        private readonly Dictionary<string, IAdvanceableDay> _nameTypeMapping;

        private static ItemMapper _instance;

        private ItemMapper()
        {
            _nameTypeMapping = new Dictionary<string, IAdvanceableDay>()
            {
                { AgedBrie.NAME, new AgedBrie() },
                { Sulfuras.NAME, new Sulfuras() },
                { BackstagePasses.NAME, new BackstagePasses() },
                { Conjured.NAME, new Conjured() },

                { GENERIC_ITEM_KEY, new GenericItem() }
            };
        }

        public static ItemMapper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ItemMapper();

                return _instance;
            }
        }

        public IAdvanceableDay GetCustomizedType(Item item)
        {
            return GetItemType(item.Name);
        }

        private IAdvanceableDay GetItemType(string itemName)
        {
            if (_nameTypeMapping.TryGetValue(itemName, out IAdvanceableDay advanceableDayItem))
                return advanceableDayItem;

            return _nameTypeMapping[GENERIC_ITEM_KEY];
        }
    }
}
