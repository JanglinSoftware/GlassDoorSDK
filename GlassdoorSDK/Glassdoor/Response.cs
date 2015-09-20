using Newtonsoft.Json;

namespace Janglin.Glassdoor.Client
{
    [JsonObject]
    public class TypedResponse<T> : Response
	{
		[JsonProperty("response")]
		public T Information { get; private set; }
	}

    [JsonObject]
    public class Response
	{
		[JsonProperty("success")]
		public bool Success { get; private set; }

		[JsonProperty("status")]
		public string Status { get; private set; }

		[JsonProperty("jsessionid")]
		public string JsessionId { get; private set; }
	}

    [JsonObject]
    public class PagedTypedResponse<T> : Response
    {
        [JsonProperty("currentPageNumber")]
        public int CurrentPageNumber { get; private set; }

        [JsonProperty("totalNumberOfPages")]
        public int TotalNumberOfPages { get; private set; }

        [JsonProperty("totalRecordCount")]
        public int TotalRecordCount { get; private set; }
    }
}