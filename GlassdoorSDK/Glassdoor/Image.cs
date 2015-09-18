using Newtonsoft.Json;

namespace Janglin.Glassdoor.Client
{
	public class Image
	{
		[JsonProperty("src")]
		public string src { get; private set; }

		[JsonProperty("height")]
		public string height { get; private set; }

		[JsonProperty("width")]
		public string width { get; private set; }

	}
}