using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Janglin.RestApiSdk;

namespace Janglin.Glassdoor.Api
{
    public class Client
    {
        /// <summary>Default constructor.</summary>
        /// <param name="partnerId">The partner ID supplied by Glassdoor.</param>
        /// <param name="key">The api key supplied by Glassdoor.</param>
        /// <param name="userIp">The IP address of the end user to whom the API results will be shown.
        /// This is an optional user IP that will be applied to all subsequent calls unless the userIp parameter is set in that specific call.</param>
        public Client(string partnerId, string key, string userIp = "0.0.0.0")
        {
            PartnerId = partnerId;
            Key = key;
            UserIp = userIp;
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
        /// <param name="userIp">The IP address of the end user to whom the API results will be shown.
        /// This is an optional user IP that will be applied to all subsequent calls unless the userIp parameter is set in that specific call.</param>
        /// <param name="userAgent">The User-Agent (browser) of the end user to whom the API results will be shown. Note that you can can obtain this from the "User-Agent" HTTP request header from the end-user.
        /// This probably doesn't apply here as this SDK is intended for Windows applications.</param>
        /// <returns></returns>
        public async Task<JobsStats> GetJobsStatsAsync(string callback = null,
            string queryPhrase = null,
            string employer = null,
            string location = null,
            int? city = null,
            string state = null,
            string country = null,
            string fromAgeDays = null,
            JobType? jobType = null,
            byte? minRating = null,
            int? radius = null,
            string jobTitle = null,
            JobCategory? jobCategory = null,
            bool? returnCities = null,
            bool? returnStates = null,
            bool? returnJobTitles = null,
            bool? returnEmployers = null,
            byte? admLevelRequested = null,
            string userIp = null,
            string userAgent = "")
        {
            var url = "http://api.glassdoor.com/api/api.htm".Parameters("action", "jobs-stats",
                "v", "1",
                "format", "json",
                "t.p", PartnerId,
                "t.k", Key,
                "userip", DetermineUserIp(userIp),
                "useragent", userAgent,
                "callback", callback,
                "q", queryPhrase,
                "e", employer.ToStringIfNotNull(),
                "l", location,
                "city", city.ToStringIfNotNull(),
                "state", state.ToStringIfNotNull(),
                "country", country,
                "fromAge", fromAgeDays,
                "jobType", jobType.ToStringIfNotNull(),
                "minRating", minRating.ToStringIfNotNull(),
                "jt", jobTitle,
                "jc", jobCategory.ToStringIfNotNull(),
                "returnCities", returnCities.ToStringIfNotNull(),
                "returnStates", returnStates.ToStringIfNotNull(),
                "returnJobTitles", returnJobTitles.ToStringIfNotNull(),
                "returnEmployers", returnEmployers.ToStringIfNotNull(),
                "admLevelRequested", admLevelRequested.ToStringIfNotNull());

            return await WebRequester.GetAsync<JobsStats>(url);
        }

        /// <summary>A job progression request must specify "jobs-prog" for the action parameter in addition to the other required parameters, as well as specify a required country id (1=US is the only country supported right now), and a job title.</summary>
        /// <param name="jobTitle">Job Title - the job title to get related jobs for</param>
        /// <param name="userIp">The IP address of the end user to whom the API results will be shown.
        /// This is an optional user IP that will be applied to all subsequent calls unless the userIp parameter is set in that specific call.</param>
        /// <param name="userAgent">The User-Agent (browser) of the end user to whom the API results will be shown. Note that you can can obtain this from the "User-Agent" HTTP request header from the end-user.
        /// This probably doesn't apply here as this SDK is intended for Windows applications.</param>
        /// <param name="callBack">If json is the requested format, you may specify a jsonp callback here, allowing you to make cross-domain calls to the glassdoor API from your client-side javascript. See the JSONP wikipedia entry for more information on jsonp.</param>
        /// <param name="countryId">Country Id - only 1 (US) is supported right now.</param>
        /// <returns></returns>
        public async Task<JobsProgression> GetJobsProgressionAsync(string jobTitle,
            string userIp = null,
            string userAgent = "",
            string callBack = null,
            int countryId = 1)
        {
            var url = "http://api.glassdoor.com/api/api.htm".Parameters("action", "jobs-prog",
                "v", "1",
                "format", "json",
                "t.p", PartnerId,
                "t.k", Key,
                "userip", DetermineUserIp(userIp),
                "useragent", userAgent,
                "callback", callBack,
                "jobTitle", jobTitle,
                "countryId", 1.ToStringIfNotNull());

            return await WebRequester.GetAsync<JobsProgression>(url);
        }

        /// <summary>
        /// A company search request must specify "employers" for the action parameter in addition to the other required parameters, and then can optionally scope the search using the parameters below.
        /// </summary>
        /// <param name="pageNumber">Page number to retrieve. Default is 1.</param>
        /// <param name="pageSize">Page size, i.e. the number of jobs returned on each page of results. Default is 20.</param>
        /// <param name="queryPhrase">Query phrase to search for - can be any combination of employer or occupation, but location should be in l param.</param>
        /// <param name="location">Scope the search to a specific location by specifying it here - city, state, or country.</param>
        /// <param name="city"> Scope the search to a specific city by specifying it here. </param>
        /// <param name="state">Scope the search to a specific state by specifying it here.</param>
        /// <param name="country">Scope the search to a specific country by specifying it here.</param>
        /// <param name="userIp">The IP address of the end user to whom the API results will be shown.
        /// This is an optional user IP that will be applied to all subsequent calls unless the userIp parameter is set in that specific call.</param>
        /// <param name="userAgent">The User-Agent (browser) of the end user to whom the API results will be shown. Note that you can can obtain this from the "User-Agent" HTTP request header from the end-user.
        /// This probably doesn't apply here as this SDK is intended for Windows applications.</param>
        /// <param name="callBack"> If json is the requested format, you may specify a jsonp callback here, allowing you to make cross-domain calls to the glassdoor API from your client-side javascript. See the JSONP wikipedia entry for more information on jsonp.</param>
        /// <returns>A <see cref="CompanySearchResult"/> object containing requested data.</returns>
        /// <remarks>http://www.glassdoor.com/api/companiesApiActions.htm</remarks>
        public async Task<CompanySearchResult> GetCompaniesAsync(int pageNumber = 1,
            int pageSize = 20,
            string queryPhrase = null,
            string location = null,
            int? city = null,
            int? state = null,
            int? country = null,
            string userIp = null,
            string userAgent = "",
            string callBack = null)
        {
            var url = "http://api.glassdoor.com/api/api.htm".Parameters("action", "employers",
                "v", "1",
                "format", "json",
                "t.p", PartnerId,
                "t.k", Key,
                "userip", DetermineUserIp(userIp),
                "useragent", userAgent,
                "queryPhrase", callBack,
                "location", location,
                "city", city.ToStringIfNotNull(),
                "state", state.ToStringIfNotNull(),
                "country", country.ToStringIfNotNull(),
                "pn", pageNumber.ToStringIfNotNull(),
                "ps", pageSize.ToStringIfNotNull());

            return await WebRequester.GetAsync<CompanySearchResult>(url);
        }

        /// <summary>A company search request must specify "employers" for the action parameter in addition to the other required parameters, and then can optionally scope the search using the parameters below.
        /// <param name="queryPhrase"></param>
        /// <param name="location"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="country"></param>
        /// <param name="userIp">The IP address of the end user to whom the API results will be shown.
        /// This is an optional user IP that will be applied to all subsequent calls unless the userIp parameter is set in that specific call.</param>
        /// <param name="userAgent">The User-Agent (browser) of the end user to whom the API results will be shown. Note that you can can obtain this from the "User-Agent" HTTP request header from the end-user.
        /// This probably doesn't apply here as this SDK is intended for Windows applications.</param>
        /// <param name="callBack"></param>
        /// <returns>A collection of all companies returned by this search starting with the first one on the first page and ending with the last one on the last page.</returns>
        /// <remarks>This method uses and custom enumerator which retrieves data according to the method parameters and continuously retrieves following pages if and when the Next
        /// method is called on the enumerator and the present page is exhausted (i.e. Next() returns null). This allows front end development to create continous list/grid displays
        /// without concern for the API's pagination.
        /// <para>WARNING: Do not use LINQ to Objects to filter the result of this call. Use the parameters supplied with this method to filter the call. These parameters will 
        /// be passed to the Glassdoor API server thru the HTTP request making the Glassdoor server perform the work for which it was designed.</para>
        /// <para>If you need to more precisly control pagination, please use <see cref="GetCompaniesAsync(int, int, string, string, int?, int?, int?, string, string, string)>."/></para>
        /// <para>http://www.glassdoor.com/api/companiesApiActions.htm</para>
        /// </remarks>
        public IEnumerable<DetailedEmployer> GetCompanies(string queryPhrase = null,
            string location = null,
            int? city = null,
            int? state = null,
            int? country = null,
            string userIp = null,
            string userAgent = "",
            string callBack = null,
			int pageSize = 1000)
        {
            var url = "http://api.glassdoor.com/api/api.htm".Parameters("action", "employers",
                "v", "1",
                "format", "json",
                "t.p", PartnerId,
                "t.k", Key,
                "userip", DetermineUserIp(userIp),
                "useragent", userAgent,
                "queryPhrase", callBack,
                "location", location,
                "city", city.ToStringIfNotNull(),
                "state", state.ToStringIfNotNull(),
                "country", country.ToStringIfNotNull(),
                "pn", "{0}",
                "ps", "{1}");

            return new PagedResult<CompanySearchResult, DetailedEmployer>(url) { PageSize = pageSize,};
        }

        /// <summary>Determines whether the method caller is setting the user IP for that call, 
        /// and if not whether the user set it for this Client instance.</summary>
        /// <param name="userIp">Value used to override the class property.</param>
        /// <returns>Value for that HTTP request to use.</returns>
        string DetermineUserIp(string userIp)
        {
            if (String.IsNullOrWhiteSpace(userIp))
            {
                if (String.IsNullOrWhiteSpace(UserIp))
                    return "0.0.0.0";
                else return UserIp;
            }
            else
                return userIp;
        }
    }
}