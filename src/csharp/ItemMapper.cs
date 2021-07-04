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
                { AgedBrieItemsRules.NAME, new AgedBrieItemsRules() },
                { SulfurasItemRules.NAME, new SulfurasItemRules() },
                { BackstagePassesItemRules.NAME, new BackstagePassesItemRules() },
                { ConjuredItemRules.NAME, new ConjuredItemRules() },

                { GENERIC_ITEM_KEY, new GenericItemRules() }
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
