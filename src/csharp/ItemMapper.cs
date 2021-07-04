using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace csharp
{
    public class ItemMapper
    {
        private const string GENERIC_ITEM_KEY = "default";

        private readonly Dictionary<string, IAdvanceableDay> _nameTypeMapping;

        private static ItemMapper _instance;
        public static ItemMapper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ItemMapper();

                return _instance;
            }
        }

        private ItemMapper()
        {
            _nameTypeMapping = new Dictionary<string, IAdvanceableDay>()
            {
                { GENERIC_ITEM_KEY, new GenericItem() }
            };

            LoadDictionaryWithReflection();
        }

        public IAdvanceableDay GetMappedTypeFor(Item item)
        {
            if (_nameTypeMapping.TryGetValue(item.Name, out IAdvanceableDay advanceableDayItem))
                return advanceableDayItem;

            return _nameTypeMapping[GENERIC_ITEM_KEY];
        }

        private void LoadDictionaryWithReflection()
        {
            var specializedItemsTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetCustomAttribute<SpecializedItemAttribute>() != null);

            foreach (Type type in specializedItemsTypes)
            {
                var itemName = type.GetCustomAttribute<SpecializedItemAttribute>().ItemName;

                /// If the class does not implement <see cref="IAdvanceableDay"/> it won't be 
                /// added to the mapping and will be returned as GenericItem
                if (Activator.CreateInstance(type) is IAdvanceableDay instance)
                    _nameTypeMapping.Add(itemName, instance);
            }
        }
    }
}
