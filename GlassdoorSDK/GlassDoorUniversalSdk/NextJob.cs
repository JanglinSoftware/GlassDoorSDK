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

		public override bool Equals(object obj)
		{
			var input = obj as NextJob;

			if (input == null)
				return false;
			else {
				return input.NextJobTitle.Equals(NextJobTitle)
					&& input.Frequency.Equals(Frequency)
					&& input.FrequencyPercent.Equals(FrequencyPercent)
					&& input.NationalJobCount.Equals(NationalJobCount)
					&& input.MedianSalary.Equals(MedianSalary);
			}
		}

		public override int GetHashCode()
		{
			return NextJobTitle.GetHashCode()
				^ Frequency.GetHashCode()
				^ FrequencyPercent.GetHashCode()
				^ NationalJobCount.GetHashCode()
				^ MedianSalary.GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("{0} ({1})", NextJobTitle, Frequency);
		}
	}
}