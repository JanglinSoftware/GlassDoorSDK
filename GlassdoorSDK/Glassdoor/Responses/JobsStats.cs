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

		[JsonProperty("countsReturned")]
		public int CountsReturned { get; private set; }

		[JsonProperty("cities")]
		public IEnumerable<City> Cities { get; private set; }

		[JsonProperty("states")]
		public IDictionary<string, State> States { get; private set; }

		[JsonProperty("jobTitles")]
		public IEnumerable<JobTitle> JobTitles { get; private set; }

		[JsonProperty("employers")]
		public IEnumerable<Employer> Employers { get; private set; }

	}
}