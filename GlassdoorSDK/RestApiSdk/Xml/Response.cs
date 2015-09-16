using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Janglin.RestApiSdk.Xml
{
	public abstract class Response : RestApiSdk.Response
	{
		public Response() { }
		internal Response(XElement parent, string tagName, string nameSpace = null)
		{
			Element = parent.Element(tagName.Xmlns(nameSpace));
		}
		internal Response(Verb verb, string authentication) : base(verb, authentication) { }


		XElement _Element;

		protected internal virtual XElement Element
		{
			get
			{
				if (_Element == null)
					_Element = ParseResponse(WebResponseTask).Root;

				return _Element;
			}
			set { _Element = value; }
		}

		static XDocument ParseResponse(Task<WebResponse> webResponseTask)
		{
			try
			{
				webResponseTask.Wait();

				using (var datastream = webResponseTask.Result.GetResponseStream())
				{
					using (var reader = new StreamReader(datastream))
					{
						var value = reader.ReadToEnd();
						return XDocument.Parse(value);
					}
				}
			}
			catch (AggregateException ex)
			{
				var webexceptions = ex.InnerExceptions
					.Where(e => e.GetType().Equals(typeof(WebException)))
					.Select(e => e as WebException);

				if (webexceptions.Count() > 0)
					throw new RestException(webexceptions.First());
				else
					throw;
			}
			finally { webResponseTask.Result.Dispose(); }
		}

		const string _ContentType = "application/xml";
		const string _Accept = "application/xml";

		protected override string Accept { get { return _ContentType; } }

		protected override string ContentType { get { return _Accept; } }
	}
}