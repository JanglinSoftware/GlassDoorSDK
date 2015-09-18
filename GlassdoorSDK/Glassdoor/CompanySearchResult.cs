using Newtonsoft.Json;
using System.Collections.Generic;

namespace Janglin.Glassdoor.Client
{
	public class CompanySearchResult
	{
		[JsonProperty("currentPageNumber")]
		public string CurrentPageNumber { get; private set; }

		[JsonProperty("totalNumberOfPages")]
		public string TotalNumberOfPages { get; private set; }

		[JsonProperty("totalRecordCount")]
		public string TotalRecordCount { get; private set; }

		[JsonProperty("employers")]
		public IEnumerable<DetailedEmployer> DetailedEmployers{ get; private set; }
	}
}