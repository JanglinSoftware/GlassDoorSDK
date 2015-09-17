using Newtonsoft.Json;

namespace Responses
{
	public class Employer
	{
		[JsonProperty("id")]
		public string Id { get; private set; }

		[JsonProperty("name")]
		public string Name { get; private set; }

		[JsonProperty("numJobs")]
		public int NumJobs { get; private set; }

		[JsonProperty("squareLogo")]
		public string SquareLogo { get; private set; }

		[JsonProperty("rating")]
		public decimal Rating { get; private set; }

		[JsonProperty("numberOfReviews")]
		public int NumberOfReviews { get; private set; }

		[JsonProperty("starImageSrc")]
		public string StarImageSrc { get; private set; }

		[JsonProperty("reviewsUrl")]
		public string ReviewsUrl { get; private set; }
	}
}