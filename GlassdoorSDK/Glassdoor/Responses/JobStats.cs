using Janglin.Glassdoor.Client.Classic;
using Janglin.RestApiSdk;

namespace Responses
{
	public class JobStats : Janglin.RestApiSdk.Json.Response
	{
		public JobStats(string partnerId, string key, string callback, string queryPhrase, string employer, string location, string city, string state, string country, string fromAgeDays, JobType jobType, byte minRating, int radius, string jobTitle, JobCategory jobCategory, string returnCities, string returnStates, string returnJobTitles, string returnEmployers, byte admLevelRequested)
		{
			var url = "http://api.glassdoor.com/api/api.htm".Parameters("v", "1.1",
				"format", "json",
				"t.p", partnerId,
				"t.k", key,
				"userip", "",
				"useragent", "",
				"callback", callback,
				"action", "job-stats",
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

			RunVerb(url);
		}
	}
}