using Janglin.RestApiSdk;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Janglin.Glassdoor.Client
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
        public async Task<JobsStats> GetJobsStatsAsync(string callback = null,
            string queryPhrase = null,
            int? employer = null,
            string location = null,
            int? city = null,
            int? state = null,
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
            string userIp = "0.0.0.0",
            string userAgent = "")
        {
            var url = "http://api.glassdoor.com/api/api.htm".Parameters("action", "jobs-stats",
                "v", "1",
                "format", "json",
                "t.p", PartnerId,
                "t.k", Key,
                "userip", userIp,
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

            var response = await RunVerbAsync(url, Verb.Get);
            var result = ParseResponse(response);

            var json = JsonConvert.DeserializeObject<Response<JobsStats>>(result);

            if (json.Success)
                return json.Information as JobsStats;
            else
                throw new GlassdoorException(json);
        }

        public async Task<JobsProgression> GetJobProgressionAsync(string jobTitle,
            string userip = "0.0.0.0",
            string userAgent = "",
            string callBack = null,
            int countryId = 1)
        {
            var url = "http://api.glassdoor.com/api/api.htm".Parameters("action", "jobs-stats",
                "v", "1.1",
                "format", "json",
                "t.p", PartnerId,
                "t.k", Key,
                "userip", UserIp,
                "useragent", userAgent,
                "callback", callBack,
                "action", "jobs-prog",
                "jobTitle", jobTitle,
                "countryId", 1.ToStringIfNotNull());

            var response = await RunVerbAsync(url, Verb.Get);
            var result = ParseResponse(response);

            var json = JsonConvert.DeserializeObject<Response<JobsProgression>>(result);

            if (json.Success)
                return json.Information as JobsProgression;
            else
                throw new GlassdoorException(json);
        }

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


        async Task<WebResponse> RunVerbAsync(string Url, Verb verb, Request request = null)
        {
            switch (verb)
            {
                case Verb.Get:
                    return await GetAsync(Url);
                case Verb.Post:
                    return await PostAsync(Url, request);
                case Verb.Put:
                    throw new NotImplementedException();
                case Verb.Delete:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected async Task<WebResponse> GetAsync(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "GET";
            //request.ContentType = "application/json";
            //request.Accept = "application/json";

            return await request.GetResponseAsync();
        }

        protected async Task<WebResponse> PostAsync(string url, Request requestbody)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "POST";

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

            request.Method = "PUT";

            return await request.GetResponseAsync();
        }

        static async Task<WebResponse> DeleteAsync(string url, string authentication)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "DELETE";

            return await request.GetResponseAsync();
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
                    finally { if (reader != null) reader.Dispose(); }
                }
            }
        }
    }
}