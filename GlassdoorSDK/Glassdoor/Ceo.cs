using Newtonsoft.Json;

namespace Janglin.Glassdoor.Api
{
	public class Ceo
	{
		[JsonProperty("name")]
		public string Name { get; private set; }

		[JsonProperty("title")]
		public string Title { get; private set; }

		[JsonProperty("numberOfRatings")]
		public int NumberOfRatings { get; private set; }

		[JsonProperty("pctApprove")]
		public decimal ApprovalPercentage { get; private set; }

		[JsonProperty("pctDisapprove")]
		public decimal DisapprovalPercentage { get; private set; }

		[JsonProperty("image")]
		public Image Image { get; private set; }
	}
}