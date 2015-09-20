using Newtonsoft.Json;

namespace Janglin.Glassdoor.Api
{
	public class City
	{
		[JsonProperty("numJobs")]
		public int NumberOfJobs { get; private set; }

		[JsonProperty("name")]
		public string Name { get; private set; }

		[JsonProperty("stateAbbreviation")]
		public string StateAbbreviation { get; private set; }

		[JsonProperty("stateName")]
		public string StateName{ get; private set; }

		[JsonProperty("id")]
		public int Id { get; private set; }

		[JsonProperty("latitude")]
		public decimal Latitude{ get; private set; }

		[JsonProperty("longitude")]
		public decimal Longitude { get; private set; }
	}
}