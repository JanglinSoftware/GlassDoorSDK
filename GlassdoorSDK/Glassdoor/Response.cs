using Newtonsoft.Json;

namespace Janglin.Glassdoor.Client
{
	public class Response<T>
	{
		[JsonProperty("success")]
		public bool Success { get; private set; }
		[JsonProperty("status")]
		public string Status { get; private set; }
		[JsonProperty("jsessionid")]
		public string JsessionId { get; private set; }

		[JsonProperty("response")]
		public T Information { get; private set; }
	}
}