using Newtonsoft.Json;

namespace Janglin.Glassdoor.Api
{
	public class Employer
	{
		[JsonProperty("id")]
		public int Id { get; private set; }

		[JsonProperty("name")]
		public string Name { get; private set; }

		[JsonProperty("numJobs")]
		public int NumJobs { get; private set; }

		[JsonProperty("squareLogo")]
		public string SquareLogo { get; private set; }

		[JsonProperty("rating")]
		public decimal Rating { get; private set; }

		[JsonProperty("numberOfReviews")]
		public int NumberOfReviews { get; private set; }

		[JsonProperty("starImageSrc")]
		public string StarImageSrc { get; private set; }

		[JsonProperty("reviewsUrl")]
		public string ReviewsUrl { get; private set; }

		public override bool Equals(object obj)
		{
			var input = obj as Employer;

			if (input == null)
				return false;
			else
			{
				return input.Id.Equals(Id)
					&& input.Name.Equals(Name)
					&& input.NumJobs.Equals(NumJobs)
					&& input.SquareLogo.Equals(SquareLogo)
					&& input.Rating.Equals(Rating)
					&& input.NumberOfReviews.Equals(NumberOfReviews)
					&& input.StarImageSrc.Equals(StarImageSrc)
					&& input.ReviewsUrl.Equals(ReviewsUrl);
			}
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode()
				^ Name.GetHashCode()
				^ NumJobs.GetHashCode()
				^ SquareLogo.GetHashCode()
				^ Rating.GetHashCode()
				^ NumberOfReviews.GetHashCode()
				^ StarImageSrc.GetHashCode()
				^ ReviewsUrl.GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("{0}, {1}", Name, Id);
		}
	}
}