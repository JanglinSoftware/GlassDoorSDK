using Newtonsoft.Json;

namespace Janglin.Glassdoor.Api
{
	public class State
	{
		[JsonProperty("numJobs")]
		public int NumberOfJobs { get; private set; }

		[JsonProperty("name")]
		public string Name { get; private set; }

		[JsonProperty("id")]
		public int Id { get; private set; }

		[JsonProperty("score")]
		public decimal Score { get; private set; }

		[JsonProperty("latitude")]
		public decimal? Latitude { get; private set; }

		[JsonProperty("longitude")]
		public decimal? Longitude { get; private set; }

		public override bool Equals(object obj)
		{
			var input = obj as City;

			if (input == null)
				return false;
			else {
				return input.NumberOfJobs.Equals(NumberOfJobs)
					&& input.Name.Equals(Name)
					&& input.Id.Equals(Id)
					&& input.Id.Equals(Score)
					&& input.Latitude.Equals(Latitude)
					&& input.Longitude.Equals(Longitude);
			}
		}

		public override int GetHashCode()
		{
			return NumberOfJobs.GetHashCode()
				^ Name.GetHashCode()
				^ Id.GetHashCode()
				^ Score.GetHashCode()
				^ Latitude.GetHashCode()
				^ Longitude.GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("{0} ({1})", Name, Score);
		}
	}
}