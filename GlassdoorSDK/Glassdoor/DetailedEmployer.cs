using Newtonsoft.Json;

namespace Janglin.Glassdoor.Client
{
	public class DetailedEmployer : Employer
	{
		[JsonProperty("attributionURL")]
		public string AttributionURL { get; private set; }

		[JsonProperty("website")]
		public string Website { get; private set; }

		[JsonProperty("isEEP")]
		public string IsEEP { get; private set; }

		[JsonProperty("exactMatch")]
		public string ExactMatch { get; private set; }

		[JsonProperty("industry")]
		public string Industry { get; private set; }

		[JsonProperty("numberOfRatings")]
		public string NumberOfRatings { get; private set; }

		[JsonProperty("overallRating")]
		public string OverallRating { get; private set; }

		[JsonProperty("ratingDescription")]
		public string RatingDescription { get; private set; }

		[JsonProperty("cultureAndValuesRating")]
		public string CultureAndValuesRating { get; private set; }

		[JsonProperty("seniorLeadershipRating")]
		public string SeniorLeadershipRating { get; private set; }

		[JsonProperty("compensationAndBenefitsRating")]
		public string CompensationAndBenefitsRating { get; private set; }

		[JsonProperty("careerOpportunitiesRating")]
		public string CareerOpportunitiesRating { get; private set; }

		[JsonProperty("workLifeBalanceRating")]
		public string WorkLifeBalanceRating { get; private set; }

		[JsonProperty("featuredReview")]
		public FeaturedReview FeaturedReview { get; private set; }

		[JsonProperty("ceo")]
		public Ceo Ceo { get; private set; }
	}
}