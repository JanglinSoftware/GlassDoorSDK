using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

namespace Janglin.Glassdoor.Api
{
	[JsonObject]
	public class CompanySearchResult : PagedTypedResponse<DetailedEmployer>, IEnumerable<DetailedEmployer>
	{
		[JsonProperty("employers")]
		internal IEnumerable<DetailedEmployer> DetailedEmployers { get; private set; }

		public IEnumerator<DetailedEmployer> GetEnumerator()
		{
			return DetailedEmployers.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return DetailedEmployers.GetEnumerator();
		}

		public override bool Equals(object obj)
		{
			var input = obj as CompanySearchResult;

			if (input == null)
				return false;
			else {
				return input.DetailedEmployers.Equals(DetailedEmployers);
			}
		}

		public override int GetHashCode()
		{
			return DetailedEmployers.GetHashCode();
		}
	}
}