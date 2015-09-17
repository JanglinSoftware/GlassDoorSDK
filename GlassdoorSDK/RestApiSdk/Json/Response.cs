using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Janglin.RestApiSdk.Json
{
	public abstract class Response : Janglin.RestApiSdk.Response
    {
        public Response() { }
        internal Response(object parent, string tagName)
        {
            //Object = parent.Element(tagName.Xmlns(nameSpace));
        }

        //object _Object;
        //protected internal virtual object Object
        //{
        //    get
        //    {
        //        if (_Object == null)
        //            _Object = ParseResponse(WebResponseTask);

        //        return _Object;
        //    }
        //    set { _Object = value; }
        //}

        internal static T ParseResponse<T>(Task<WebResponse> webResponseTask)
        {
            try
            {
                webResponseTask.Wait();

                using (var datastream = webResponseTask.Result.GetResponseStream())
                {
                    using (var reader = new StreamReader(datastream))
                    {
                        var value = reader.ReadToEnd();

                        return JsonConvert.DeserializeObject<T>(value);
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