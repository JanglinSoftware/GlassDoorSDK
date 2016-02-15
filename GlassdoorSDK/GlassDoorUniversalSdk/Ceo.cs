using Newtonsoft.Json;

namespace Janglin.Glassdoor.Api
{
	public class Ceo
	{
		[JsonProperty("name")]
		public string Name { get; private set; }

		[JsonProperty("title")]
		public string Title { get; private set; }

		[JsonProperty("numberOfRatings")]
		public int NumberOfRatings { get; private set; }

		[JsonProperty("pctApprove")]
		public decimal ApprovalPercentage { get; private set; }

		[JsonProperty("pctDisapprove")]
		public decimal DisapprovalPercentage { get; private set; }

		[JsonProperty("image")]
		public Image Image { get; private set; }

		public override bool Equals(object obj)
		{
			var input = obj as Ceo;

			if (input == null)
				return false;
			else {
				return input.Name.Equals(Name)
					&& input.Title.Equals(Title)
					&& input.NumberOfRatings.Equals(NumberOfRatings)
					&& input.ApprovalPercentage.Equals(ApprovalPercentage)
					&& input.DisapprovalPercentage.Equals(DisapprovalPercentage)
					&& input.Image.Equals(Image);
			}
		}

		public override int GetHashCode()
		{
			return Name.GetHashCode()
				^ Title.GetHashCode()
				^ NumberOfRatings.GetHashCode()
				^ ApprovalPercentage.GetHashCode()
				^ DisapprovalPercentage.GetHashCode()
				^ Image.GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("{0}, {1}", Name, Title);
		}
	}
}