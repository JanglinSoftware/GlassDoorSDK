using System;

namespace Janglin.RestApiSdk.Xml
{
    internal class ComplexArrayPropertyAttribute : Attribute
    {
        public string CollectionTagName { get; set; }
        public string ItemTagName { get; set; }

        public ComplexArrayPropertyAttribute(string collectionTagName, string itemTagName)
        {
            this.CollectionTagName = collectionTagName;
            this.ItemTagName = itemTagName;
        }
    }
}