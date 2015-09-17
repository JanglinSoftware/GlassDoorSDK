using Janglin.Glassdoor.Client.Classic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Responses
{
	[JsonObject]
	public class JobsStats 
	{
		[JsonProperty("attributionURL")]
		public string AttributionUrl { get; private set; }

			RunVerb(url);
		}

		public object Test
		{
			get
			{
				try
				{
					WebResponseTask.Wait();

					return WebResponseTask.Result;
				}
				catch (AggregateException ex)
				{
					var webex = ex.InnerException as WebException;

					if (webex != null) {
						HandleWebException(webex);


					}

				}

				throw new NotImplementedException();
			}
		}

		private void HandleWebException(WebException ex)
		{
			var httpresponse = (HttpWebResponse)ex.Response;

			if (httpresponse != null)
			{
				System.Diagnostics.Debug.WriteLine("Error code: {0}", httpresponse.StatusCode);

		[JsonProperty("states")]
		public IDictionary<string, State> States { get; private set; }

		[JsonProperty("jobTitles")]
		public IEnumerable<JobTitle> JobTitles { get; private set; }

		[JsonProperty("employers")]
		public IEnumerable<Employer> Employers { get; private set; }

	}
}