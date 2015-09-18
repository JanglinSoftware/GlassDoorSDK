using Newtonsoft.Json;

namespace Janglin.Glassdoor.Client
{
	public class Ceo
	{
		[JsonProperty("name")]
		public string name { get; private set; }

		[JsonProperty("title")]
		public string title { get; private set; }

		[JsonProperty("numberOfRatings")]
		public string numberOfRatings { get; private set; }

		[JsonProperty("pctApprove")]
		public string pctApprove { get; private set; }

		[JsonProperty("pctDisapprove")]
		public string pctDisapprove { get; private set; }

		[JsonProperty("image")]
		public Image image { get; private set; }
	}
}