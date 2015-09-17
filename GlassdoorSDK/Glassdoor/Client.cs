using Janglin.RestApiSdk;
using System;

namespace Janglin.Glassdoor.Client.Classic
{
	public class Client
	{
		public Client(string partnerId, string key)
		{
			PartnerId = partnerId;
			Key = key;
		}

		public string Key { get; private set; }
		public string PartnerId { get; private set; }
        public string UserIp { get; private set; }

        /// <summary>A jobs stats request must specify "jobs-stats" for the action parameter in addition to the other required parameters, and then can optionally scope the search using the parameters below.</summary>
        /// <remarks>See: http://www.glassdoor.com/api/jobsApiActions.htm </remarks>
        /// <param name="callback">If json is the requested format, you may specify a jsonp callback here, allowing you to make cross-domain calls to the glassdoor API from your client-side javascript.</param>
        /// <param name="queryPhrase">Query phrase to search for - can be any combination of employer or occupation, but location should be in l param.</param>
        /// <param name="employer">Scope the search to a specific employer by specifying the name here.</param>
        /// <param name="location">Scope the search to a specific location by specifying it here - city, state, or country.</param>
        /// <param name="city">Scope the search to a specific city by specifying it here.</param>
        /// <param name="state">Scope the search to a specific state by specifying it here.</param>
        /// <param name="country">Scope the search to a specific country by specifying it here.</param>
        /// <param name="fromAgeDays">Scope the search to jobs that are less than X days old (-1 = show all jobs (default), 1 = 1 day old, 7 = 1 week old, 14 = 2 weeks old, etc.)</param>
        /// <param name="jobType">Scope the search to certain job types. Valid values are all (default), fulltime, parttime, internship, contract, internship, temporary</param>
        /// <param name="minRating">Scope the search to jobs of companies with rating >= minRating (0 = returns all (default), 1 = more than 1 star, 2 = more than 2 stars, 3 = more than 3 stars, 4 = more than 4 stars)</param>
        /// <param name="radius">Scope the search to jobs within a certain radius, in miles, of the location specified.</param>
        /// <param name="jobTitle">Scope the search to a specific job title by specifying it here.</param>
        /// <param name="jobCategory">Job category id to scope the search to - see the Job Category table below - note you must pass the id. This can be a comma separated list of ids if you desire to select more than one category.</param>
        /// <param name="returnCities">Results will include geographical data (job counts) broken down by city.</param>
        /// <param name="returnStates">Results will include geographical data (job counts, score) broken down by the type of geographical district specified in parameter admLevelRequested.</param>
        /// <param name="returnJobTitles">Results will include job data broken down by job title.</param>
        /// <param name="returnEmployers">Results will include job data broken down by employer.</param>
        /// <param name="admLevelRequested">Geographic district type requested when returnStates is true (1 = states, 2 = counties)</param>
        /// <returns></returns>
        public async Responses.JobsStats GetJobsAsync(string callback,
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
			byte? admLevelRequested)
		{
            var url = "http://api.glassdoor.com/api/api.htm".Parameters("action", "jobs-stats",
        "v", "1",
        "format", "json",
        "t.p", PartnerId,
        "t.k", Key,
        "userip", UserIp,
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







            return Responses.JobsStats(PartnerId,
				Key,
				callback, 
				queryPhrase, 
				employer, 
				location, 
				city, 
				state, 
				country, 
				fromAgeDays, 
				jobType, 
				minRating, 
				radius, 
				jobTitle, 
				jobCategory, 
				returnCities, 
				returnStates, 
				returnJobTitles, 
				returnEmployers, 
				admLevelRequested);
		}
	}
}