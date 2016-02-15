using Janglin.Glassdoor.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Janglin.Glassdoor.Api
{
	[JsonObject]
	public class JobsStats 
	{
		[JsonProperty("attributionURL")]
		public string AttributionUrl { get; private set; }

		[JsonProperty("states")]
		public IDictionary<string, State> States { get; private set; }

		[JsonProperty("jobTitles")]
		public IEnumerable<JobTitle> JobTitles { get; private set; }

		[JsonProperty("employers")]
		public IEnumerable<Employer> Employers { get; private set; }

        [JsonProperty("cities")]
        public IEnumerable<City> Cities { get; private set; }

		public override bool Equals(object obj)
		{
			var input = obj as JobsStats;

			if (input == null)
				return false;
			else {
				return input.AttributionUrl.Equals(AttributionUrl)
					&& input.States.Equals(States)
					&& input.JobTitles.Equals(JobTitles)
					&& input.Employers.Equals(Employers)
					&& input.Cities.Equals(Cities);
			}
		}

		public override int GetHashCode()
		{
			return AttributionUrl.GetHashCode()
				^ States.GetHashCode()
				^ JobTitles.GetHashCode()
				^ Employers.GetHashCode()
				^ Cities.GetHashCode();
		}

		public override string ToString()
		{
			return AttributionUrl;
		}
	}
}