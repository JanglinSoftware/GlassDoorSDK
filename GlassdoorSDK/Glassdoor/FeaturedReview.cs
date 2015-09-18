using Newtonsoft.Json;

namespace Janglin.Glassdoor.Client
{
	public class FeaturedReview
	{
		[JsonProperty("id")]
		public string id { get; private set; }

		[JsonProperty("currentJob")]
		public string currentJob { get; private set; }

		[JsonProperty("reviewDateTime")]
		public string reviewDateTime { get; private set; }

		[JsonProperty("jobTitle")]
		public string jobTitle { get; private set; }

		[JsonProperty("location")]
		public string location { get; private set; }

		[JsonProperty("headline")]
		public string headline { get; private set; }

		[JsonProperty("pros")]
		public string pros { get; private set; }

		[JsonProperty("cons")]
		public string cons { get; private set; }
	}
}