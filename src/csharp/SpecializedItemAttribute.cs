using System;

namespace csharp
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    internal sealed class SpecializedItemAttribute : Attribute
    {
        public string ItemName { get; }

        public SpecializedItemAttribute(string itemName)
        {
            ItemName = itemName;
        }
    }
}
