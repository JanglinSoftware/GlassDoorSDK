using Janglin.Glassdoor.Client.Classic;
using Janglin.RestApiSdk;
using System;
using System.IO;
using System.Net;

namespace Responses
{
	public class JobsStats : Janglin.RestApiSdk.Json.Response
	{
		public JobsStats(string partnerId,
			string key,
			string callback,
			string queryPhrase,
			string employer,
			string location,
			string city,
			string state,
			string country,
			string fromAgeDays,
			JobType? jobType,
			byte? minRating,
			int? radius,
			string jobTitle,
			JobCategory? jobCategory,
			string returnCities,
			string returnStates,
			string returnJobTitles,
			string returnEmployers,
			byte? admLevelRequested,
			string userIp = "0.0.0.0")
		{
			var url = "http://api.glassdoor.com/api/api.htm".Parameters("action", "jobs-stats",
				"v", "1",
				"format", "json",
				"t.p", partnerId,
				"t.k", key,
				"userip", userIp,
				"useragent", "",
				"callback", callback,
				"q", queryPhrase,
				"e", employer,
				"l", location,
				"city", city,
				"state", state,
				"country", country,
				"fromAge", fromAgeDays,
				"jobType", jobType.ToString().ToLowerInvariant(),
				"minRating", minRating.ToString(),
				"jt", jobTitle,
				"jc", jobCategory.ToString().ToLowerInvariant(),
				"returnCities", returnCities,
				"returnStates", returnStates,
				"returnJobTitles", returnJobTitles,
				"returnEmployers", returnEmployers,
				"admLevelRequested", admLevelRequested.ToString());

            var result Response.ParseResponse<JobsStats>();

			RunVerb(url);
		}

		public object Test
		{
			get
			{
                var something = Object;
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
					finally
					{
						reader.DiscardBufferedData();
						reader.Dispose();
					}
				}
			}
		}
	}
}