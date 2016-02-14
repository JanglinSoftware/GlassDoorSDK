using Newtonsoft.Json;

namespace Janglin.GlassDoor.Api
{
	public class DetailedEmployer : Employer
	{
		[JsonProperty("attributionURL")]
		public string AttributionURL { get; private set; }

		[JsonProperty("website")]
		public string Website { get; private set; }

		[JsonProperty("isEEP")]
		public bool IsEEP { get; private set; }

		[JsonProperty("exactMatch")]
		public bool ExactMatch { get; private set; }

		[JsonProperty("industry")]
		public string Industry { get; private set; }

		[JsonProperty("numberOfRatings")]
		public int NumberOfRatings { get; private set; }

		[JsonProperty("overallRating")]
		public decimal OverallRating { get; private set; }

		[JsonProperty("ratingDescription")]
		public string RatingDescription { get; private set; }

		[JsonProperty("cultureAndValuesRating")]
		public decimal CultureAndValuesRating { get; private set; }

		[JsonProperty("seniorLeadershipRating")]
		public decimal SeniorLeadershipRating { get; private set; }

		[JsonProperty("compensationAndBenefitsRating")]
		public decimal CompensationAndBenefitsRating { get; private set; }

		[JsonProperty("careerOpportunitiesRating")]
		public decimal CareerOpportunitiesRating { get; private set; }

		[JsonProperty("workLifeBalanceRating")]
		public decimal WorkLifeBalanceRating { get; private set; }

		[JsonProperty("featuredReview")]
		public FeaturedReview FeaturedReview { get; private set; }

		[JsonProperty("ceo")]
		public Ceo Ceo { get; private set; }
	}
}