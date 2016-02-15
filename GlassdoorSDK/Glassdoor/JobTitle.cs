using Newtonsoft.Json;

namespace Janglin.Glassdoor.Api
{
	public class JobTitle
	{
		[JsonProperty("id")]
		public int Id { get; private set; }

		[JsonProperty("jobTitle")]
		public string Title { get; private set; }

		[JsonProperty("numJobs")]
		public string NumberOfJobs { get; private set; }

		public override bool Equals(object obj)
		{
			var input = obj as JobTitle;

			if (input == null)
				return false;
			else {
				return input.Id.Equals(Id)
					&& input.Title.Equals(Title)
					&& input.NumberOfJobs.Equals(NumberOfJobs);
			}
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode()
				^ Title.GetHashCode()
				^ NumberOfJobs.GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("{0} ({1})", Title, NumberOfJobs);
		}
	}
}