using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Collections;

namespace Janglin.Glassdoor.Client
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
    }
}