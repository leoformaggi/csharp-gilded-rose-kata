using System.Collections.Generic;

namespace csharp
{
    public class ItemMapper
    {
        private const string AGED_BRIE = AgedBrie.NAME;
        private const string SULFURAS = Sulfuras.NAME;
        private const string BACKSTAGE_PASSES = BackstagePasses.NAME;
        private const string GENERIC_ITEM = "default";

        private readonly Dictionary<string, IAdvanceableDay> _nameTypeMapping;

        private static ItemMapper _instance;

        private ItemMapper()
        {
            _nameTypeMapping = new Dictionary<string, IAdvanceableDay>()
            {
                {AGED_BRIE, new AgedBrie() },
                {SULFURAS, new Sulfuras() },
                {BACKSTAGE_PASSES, new BackstagePasses() },

                {GENERIC_ITEM, new GenericItem() }
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

            return _nameTypeMapping[GENERIC_ITEM];
        }
    }
}
