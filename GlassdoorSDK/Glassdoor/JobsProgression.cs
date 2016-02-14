using Newtonsoft.Json;
using System.Collections.Generic;

namespace Janglin.GlassDoor.Api
{
	public class JobsProgression
    {
		[JsonProperty("attributionURL")]
		public string AttributionURL { get; private set; }

		[JsonProperty("jobTitle")]
		public string JobTitle { get; private set; }

		[JsonProperty("payCurrencyCode")]
		public string PayCurrencyCode { get; private set; }

		[JsonProperty("payCurrencySymbol")]
		public string PayCurrencySymbol { get; private set; }

		[JsonProperty("payLow")]
		public decimal PayLow { get; private set; }

		[JsonProperty("payMedian")]
		public decimal PayMedian { get; private set; }

		[JsonProperty("payHigh")]
		public decimal PayHigh { get; private set; }

		[JsonProperty("results")]
		public  IEnumerable<NextJob> Results { get; private set; }
	}
}