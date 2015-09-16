using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Janglin.RestApiSdk.Xml
{
    public abstract class Response
    {
        public Response() { }
        internal Response(XElement parent, string tagName)
        {
            Element = parent.Element(tagName.DocuSignXmlns());
        }
        internal Response(Verb verb, string authentication)
        {
            AuthenticationHeader = authentication;
            Verb = verb;
        }

        protected void RunVerb(string Url, Requests.Request request = null)
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
                    throw new DocuSignException(webexceptions.First());
                else
                    throw;
            }
            finally { webResponseTask.Result.Dispose(); }
        }

        protected async Task<WebResponse> GetAsync(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Headers["X-DocuSign-Authentication"] = AuthenticationHeader;
            request.Method = "GET";
            request.ContentType = "application/xml";
            request.Accept = "application/xml";

            return await request.GetResponseAsync();
        }

        protected async Task<WebResponse> PostAsync(string url, Requests.Request requestbody)
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