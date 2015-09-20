using Newtonsoft.Json;

namespace Janglin.Glassdoor.Api
{
	public class NextJob
	{
		[JsonProperty("nextJobTitle")]
		public string NextJobTitle { get; private set; }

		[JsonProperty("frequency")]
		public int Frequency { get; private set; }

		[JsonProperty("frequencyPercent")]
		public decimal FrequencyPercent { get; private set; }

		[JsonProperty("nationalJobCount")]
		public int NationalJobCount { get; private set; }

		[JsonProperty("medianSalary")]
		public decimal MedianSalary { get; private set; }
	}
}