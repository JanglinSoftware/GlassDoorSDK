using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Janglin.RestApiSdk.Xml
{
    internal class EnumerableResponse<T>
        : Response, IEnumerable<T> where T : Response, new()
    {
        internal EnumerableResponse(string baseUrl, string collectionTagName, string itemTagName, Verb verb, string authentication, string nameSpace = null)
                 : base(verb, authentication)
        {
            ItemTagName = itemTagName;
            CollectionTagName = collectionTagName;

            RunVerb(baseUrl);

            _Collection = new Lazy<IEnumerable<T>>(() =>
            {
                var collectionelement = Element.Element(CollectionTagName.Xmlns(nameSpace));

                if (collectionelement == null)
                    return new List<T>().AsReadOnly();
                else
                    return Element
                          .Element(CollectionTagName.Xmlns(nameSpace))
                          .Elements(ItemTagName.Xmlns(nameSpace))
                          .Select(e => new T { Element = e, });
            });
        }

		internal EnumerableResponse(string baseUrl, IEnumerable<Request> requests, string collectionTagName, string itemTagName, Verb verb, string authentication, string nameSpace = null)
                 : base(verb, authentication)
        { }

        public EnumerableResponse(XElement parent, string collectionTagName, string itemTagName, string nameSpace = null) 
        {
            CollectionTagName = collectionTagName;
            ItemTagName = itemTagName;

            _Collection = new Lazy<IEnumerable<T>>(() =>
            {
                var collectionelement = parent.Element(CollectionTagName.Xmlns(nameSpace));

                if (collectionelement == null)
                    return new List<T>().AsReadOnly();
                else
                    return parent
                          .Element(CollectionTagName.Xmlns(nameSpace))
                          .Elements(ItemTagName.Xmlns(nameSpace))
                          .Select(e => new T { Element = e, });
            });
        }

        public string CollectionTagName { get; private set; }

        string ItemTagName { get; set; }

        public IEnumerator<T> GetEnumerator() { return _Collection.Value.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return _Collection.Value.GetEnumerator(); }

        Lazy<IEnumerable<T>> _Collection;
    }
}