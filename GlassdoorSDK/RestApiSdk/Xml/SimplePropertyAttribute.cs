using System;

namespace Janglin.RestApiSdk.Xml
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    internal class SimplePropertyAttribute : RequestAttribute
    {
        public SimplePropertyAttribute(string tagName) : base(tagName) { }
    }
}