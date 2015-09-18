using Newtonsoft.Json;

namespace Janglin.Glassdoor.Client
{
	internal class TypedResponse<T> : Response
	{
		[JsonProperty("response")]
		public T Information { get; private set; }
	}

	internal class Response
	{
		[JsonProperty("success")]
		public bool Success { get; private set; }

		[JsonProperty("status")]
		public string Status { get; private set; }

		[JsonProperty("jsessionid")]
		public string JsessionId { get; private set; }
	}
}