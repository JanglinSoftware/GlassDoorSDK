using Newtonsoft.Json;

namespace Janglin.Glassdoor.Api
{
	public class JobTitle
	{
		[JsonProperty("id")]
		public int Id { get; private set; }

		[JsonProperty("jobTitle")]
		public string Title { get; private set; }

		[JsonProperty("numJobs")]
		public string NumberOfJobs { get; private set; }
	}
}