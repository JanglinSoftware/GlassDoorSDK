using Janglin.RestApiSdk;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Janglin.Glassdoor.Api
{
	internal static class WebRequester
	{

		static string ParseResponse(WebResponse webResponse)
		{
			try
			{
				using (var datastream = webResponse.GetResponseStream())
				{
					using (var reader = new StreamReader(datastream))
					{
						var value = reader.ReadToEnd();
						return value;
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
			finally { webResponse.Dispose(); }
		}

		internal static async Task<T> GetAsync<T>(string url) where T : class
		{
			var request = (HttpWebRequest)WebRequest.Create(url);

			request.Method = "GET";
			//request.ContentType = "application/json";
			//request.Accept = "application/json";

			var response = await request.GetResponseAsync();

			var result = ParseResponse(response);

			var jsonresponse = JsonConvert.DeserializeObject<TypedResponse<T>>(result);

			if (jsonresponse.Success)
				return jsonresponse.Information as T;
			else
				throw new GlassdoorException(jsonresponse);

		}

		static void HandleWebException(WebException ex)
		{
			var httpresponse = (HttpWebResponse)ex.Response;

			if (httpresponse != null)
			{
				System.Diagnostics.Debug.WriteLine("Error code: {0}", httpresponse.StatusCode);

				var data = httpresponse.GetResponseStream();

				if (data != null && data.CanRead)
				{
					var reader = new StreamReader(data);

					try
					{
						var responsetext = reader.ReadToEnd();

						//if (!String.IsNullOrWhiteSpace(responsetext))
						//	Data.Add(ErrorDetailsKey, responsetext);
					}
					finally { if (reader != null) reader.Dispose(); }
				}
			}
		}
	}
}