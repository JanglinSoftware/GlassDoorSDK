using Newtonsoft.Json;

namespace Responses
{
	public class JobTitle
	{
		[JsonProperty("id")]
		public string Id { get; private set; }

		[JsonProperty("jobTitle")]
		public string Title { get; private set; }

		[JsonProperty("numJobs")]
		public string NumberOfJobs { get; private set; }
	}
}