using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Janglin.RestApiSdk.Xml
{
	public class Request
	{
		public string XmlNamespace { get; set; }

		internal byte[] ByteArrayBuffer { get { return Encoding.ASCII.GetBytes(ToXml().ToString()); } }

		internal virtual IEnumerable<XElement> ToXml()
		{
			var output = new List<XElement>();

			foreach (var property in GetType().GetProperties(BindingFlags.Public))
			{
				var simpleproperty = property.GetCustomAttribute(typeof(SimplePropertyAttribute)) as SimplePropertyAttribute;

				if (simpleproperty != null)
				{
					output.Add(new XElement(simpleproperty.TagName.Xmlns(XmlNamespace), property.GetValue(this)));
					continue;
				}

				var complexproperty = property.GetCustomAttribute(typeof(ComplexPropertyAttribute)) as ComplexPropertyAttribute;

				if (complexproperty != null)
				{
					output.Add(new XElement(complexproperty.TagName.Xmlns(XmlNamespace), ((Request)property.GetValue(this)).ToXml()));
					continue;
				}

				var complexarrayproperty = property.GetCustomAttribute(typeof(ComplexArrayPropertyAttribute)) as ComplexArrayPropertyAttribute;

				if (complexarrayproperty != null)
				{
					var collection = new XElement(complexarrayproperty.CollectionTagName.Xmlns(XmlNamespace));

					var propertyvalue = property.GetValue(this) as IEnumerable<Request>;

					collection.Add(propertyvalue.Select(pv => new XElement(complexarrayproperty.ItemTagName.Xmlns(XmlNamespace), pv.ToXml())));

					output.Add(collection);
				}
			}

			return output;
		}
	}
}