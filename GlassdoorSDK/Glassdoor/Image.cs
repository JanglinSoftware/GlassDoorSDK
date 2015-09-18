using Newtonsoft.Json;

namespace Janglin.Glassdoor.Client
{
	public class Image
	{
		[JsonProperty("src")]
		public string Source { get; private set; }

		[JsonProperty("height")]
		public string Height { get; private set; }

		[JsonProperty("width")]
		public string Width { get; private set; }

	}
}