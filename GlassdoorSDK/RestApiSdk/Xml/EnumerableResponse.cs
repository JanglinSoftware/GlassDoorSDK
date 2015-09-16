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
        internal EnumerableResponse(string baseUrl, string collectionTagName, string itemTagName, Verb verb, string authentication)
                 : base(verb, authentication)
        {
            ItemTagName = itemTagName;
            CollectionTagName = collectionTagName;

            RunVerb(baseUrl);

            _Collection = new Lazy<IEnumerable<T>>(() =>
            {
                var collectionelement = Element.Element(CollectionTagName.DocuSignXmlns());

                if (collectionelement == null)
                    return new List<T>().AsReadOnly();
                else
                    return Element
                          .Element(CollectionTagName.DocuSignXmlns())
                          .Elements(ItemTagName.DocuSignXmlns())
                          .Select(e => new T { Element = e, });
            });
        }
        //internal EnumerableResponse(string baseUrl, Requests.Request request, string collectionTagName, string itemTagName, Verb verb, string authentication)
        //         : base(verb, authentication)
        //{
        //    ItemTagName = itemTagName;
        //    CollectionTagName = collectionTagName;

        //    RunVerb(baseUrl, request);

        //    _Collection = new Lazy<IEnumerable<T>>(() =>
        //    {
        //        var collectionelement = Element.Element(CollectionTagName.DocuSignXmlns());

        //        if (collectionelement == null)
        //            return new List<T>().AsReadOnly();
        //        else
        //            return Element
        //                  .Element(CollectionTagName.DocuSignXmlns())
        //                  .Elements(ItemTagName.DocuSignXmlns())
        //                  .Select(e => new T { Element = e, });
        //    });
        //}
        internal EnumerableResponse(string baseUrl, IEnumerable<Requests.Request> requests, string collectionTagName, string itemTagName, Verb verb, string authentication)
                 : base(verb, authentication)
        { }

        public EnumerableResponse(XElement parent, string collectionTagName, string itemTagName) 
        {
            CollectionTagName = collectionTagName;
            ItemTagName = itemTagName;

            _Collection = new Lazy<IEnumerable<T>>(() =>
            {
                var collectionelement = parent.Element(CollectionTagName.DocuSignXmlns());

                if (collectionelement == null)
                    return new List<T>().AsReadOnly();
                else
                    return parent
                          .Element(CollectionTagName.DocuSignXmlns())
                          .Elements(ItemTagName.DocuSignXmlns())
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