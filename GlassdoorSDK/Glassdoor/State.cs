using Newtonsoft.Json;

namespace Janglin.Glassdoor.Client
{
	public class State
	{
		[JsonProperty("numJobs")]
		public int NumberOfJobs { get; private set; }

		[JsonProperty("name")]
		public string Name { get; private set; }

		[JsonProperty("id")]
		public int Id { get; private set; }

		[JsonProperty("score")]
		public decimal Score { get; private set; }

		[JsonProperty("latitude")]
		public decimal? Latitude { get; private set; }

		[JsonProperty("longitude")]
		public decimal? Longitude { get; private set; }
	}
}