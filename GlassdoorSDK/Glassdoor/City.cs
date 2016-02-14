using Newtonsoft.Json;

namespace Janglin.GlassDoor.Api
{
	public class City
	{
		[JsonProperty("numJobs")]
		public int NumberOfJobs { get; private set; }

		[JsonProperty("name")]
		public string Name { get; private set; }

		[JsonProperty("stateAbbreviation")]
		public string StateAbbreviation { get; private set; }

		[JsonProperty("stateName")]
		public string StateName{ get; private set; }

		[JsonProperty("id")]
		public int Id { get; private set; }

		[JsonProperty("latitude")]
		public decimal Latitude{ get; private set; }

		[JsonProperty("longitude")]
		public decimal Longitude { get; private set; }

		public override bool Equals(object obj)
		{
			var input = obj as City;

			if (input == null)
				return false;
			else {
				return input.Name.Equals(Name)
					&& input.StateAbbreviation.Equals(StateAbbreviation)
					&& input.StateName.Equals(StateName)
					&& input.Id.Equals(Id)
					&& input.Latitude.Equals(Latitude)
					&& input.Longitude.Equals(Longitude);
			}
		}

		public override int GetHashCode()
		{
			return Name.GetHashCode()
				^ StateAbbreviation.GetHashCode()
				^ StateName.GetHashCode()
				^ Id.GetHashCode()
				^ Latitude.GetHashCode()
				^ Longitude.GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("{0}, {1}", Name, StateAbbreviation);
		}
	}
}