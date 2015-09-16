using System;

namespace Janglin.RestApiSdk.Xml
{
	internal abstract class RequestAttribute : Attribute
    {
        public RequestAttribute(string tagName) { TagName = tagName; }

        public string TagName { get; set; }
    }
}