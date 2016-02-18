using System;
using System.IO;
using System.Net;

namespace Janglin.RestApiSdk
{
	public class RestException : Exception
	{
		const string ErrorDetailsKey = "ErrorDetails";

		public RestException(WebException ex)
			: base("The call to the RESTful API was unsuccessful. Please see items in the Data property collection in this exception for more information.")
		{
			if (ex == null)
				throw new ArgumentNullException("ex");
			else
			{
				HandleWebException(ex);
				Data.Add("WebExceptionMessage", ex.Message);
			}
		}

		private void HandleWebException(WebException ex)
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

						if (!String.IsNullOrWhiteSpace(responsetext))
							Data.Add(ErrorDetailsKey, responsetext);
					}
					finally
					{
						reader.DiscardBufferedData();
						reader.Dispose();
					}
				}
			}
		}

		public string ErrorDetails
		{
			get
			{
				return Data.Contains(ErrorDetailsKey)
					? (string)Data[ErrorDetailsKey]
					: String.Empty;
			}
		}

		public string WebExceptionMessage
		{
			get
			{
				try { return (string)Data["WebExceptionMessage"]; }
				catch (Exception) { return null; }
			}
		}
	}
}