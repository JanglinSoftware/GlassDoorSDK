using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Janglin.RestApiSdk
{
	public abstract class Response
	{
		public Response() { }

		internal Response(Verb verb, string authentication)
		{
			AuthenticationHeader = authentication;
			Verb = verb;
		}

		protected void RunVerb(string Url, Request request = null)
		{
			switch (Verb)
			{
				case Verb.Get:
					WebResponseTask = GetAsync(Url);
					break;
				case Verb.Post:
					WebResponseTask = PostAsync(Url, request);
					break;
				case Verb.Put:
					throw new NotImplementedException();
				//break;
				case Verb.Delete:
					throw new NotImplementedException();
				//break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		protected Task<WebResponse> WebResponseTask;
		protected Verb Verb { get; set; }

		protected string AuthenticationHeader { get; set; }

		protected abstract string ContentType { get; }
		protected abstract string Accept { get; }

		protected async Task<WebResponse> GetAsync(string url)
		{
			var request = (HttpWebRequest)WebRequest.Create(url);

			request.Headers["X-DocuSign-Authentication"] = AuthenticationHeader;
			request.Method = "GET";
			request.ContentType = "application/xml";
			request.Accept = "application/xml";

			return await request.GetResponseAsync();
		}

		protected async Task<WebResponse> PostAsync(string url, Request requestbody)
		{
			var request = (HttpWebRequest)WebRequest.Create(url);

			request.Headers["X-DocuSign-Authentication"] = AuthenticationHeader;
			request.Method = "POST";
			request.ContentType = "application/xml";
			request.Accept = "application/xml";

			var pendingrequest = request.BeginGetRequestStream(null, null);
			var requeststream = request.EndGetRequestStream(pendingrequest);

			var buffer = requestbody.ByteArrayBuffer;
			var count = buffer.Length;

			requeststream.Write(buffer, 0, count);

			return await request.GetResponseAsync();
		}

		protected async Task<WebResponse> PutAsync(string url)
		{
			var request = (HttpWebRequest)WebRequest.Create(url);

			request.Headers["X-DocuSign-Authentication"] = AuthenticationHeader;
			request.Method = "PUT";
			request.ContentType = "application/xml";
			request.Accept = "application/xml";

			return await request.GetResponseAsync();
		}

		static internal async Task<WebResponse> DeleteAsync(string url, string authentication)
		{
			var request = (HttpWebRequest)WebRequest.Create(url);

			request.Headers["X-DocuSign-Authentication"] = authentication;
			request.Method = "DELETE";
			request.ContentType = "application/xml";
			request.Accept = "application/xml";

			return await request.GetResponseAsync();
		}
	}
}