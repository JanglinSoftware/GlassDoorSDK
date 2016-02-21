using Newtonsoft.Json;

namespace Janglin.Glassdoor.Api
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

		public override bool Equals(object obj)
		{
			var input = obj as DetailedEmployer;

			if (input == null)
				return false;
			else
			{
				return input.AttributionURL.Equals(Name)
					&& input.Website.Equals(Website)
					&& input.IsEEP.Equals(IsEEP)
					&& input.ExactMatch.Equals(ExactMatch)
					&& input.Industry.Equals(Industry)
					&& input.NumberOfRatings.Equals(NumberOfRatings)
					&& input.OverallRating.Equals(OverallRating)
					&& input.RatingDescription.Equals(RatingDescription)
					&& input.CultureAndValuesRating.Equals(CultureAndValuesRating)
					&& input.SeniorLeadershipRating.Equals(SeniorLeadershipRating)
					&& input.CompensationAndBenefitsRating.Equals(CompensationAndBenefitsRating)
					&& input.CareerOpportunitiesRating.Equals(CareerOpportunitiesRating)
					&& input.WorkLifeBalanceRating.Equals(WorkLifeBalanceRating)
					&& input.FeaturedReview.Equals(FeaturedReview)
					&& input.Ceo.Equals(Ceo);
			}
		}

		public override int GetHashCode()
		{
			return AttributionURL.GetHashCode()
				^ Website.GetHashCode()
				^ IsEEP.GetHashCode()
				^ ExactMatch.GetHashCode()
				^ Industry.GetHashCode()
				^ NumberOfRatings.GetHashCode()
				^ OverallRating.GetHashCode()
				^ RatingDescription.GetHashCode()
				^ CultureAndValuesRating.GetHashCode()
				^ SeniorLeadershipRating.GetHashCode()
				^ CompensationAndBenefitsRating.GetHashCode()
				^ CareerOpportunitiesRating.GetHashCode()
				^ WorkLifeBalanceRating.GetHashCode()
				^ FeaturedReview.GetHashCode()
				^ Ceo.GetHashCode();
		}
	}
}