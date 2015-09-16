using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Janglin.RestApiSdk.Xml
{
    public abstract class ItemResponse : Response
    {
        public ItemResponse() { }

        internal ItemResponse(string id, Verb verb, string authentication)
            : base(verb, authentication)
        {
            Id = id;
        }
        internal ItemResponse(XElement parent, string tagName) : base(parent, tagName)
        {
        }

        protected string Id { get; set; }
    }
}