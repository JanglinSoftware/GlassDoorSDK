using Newtonsoft.Json;
using System;

namespace Janglin.GlassDoor.Api
{
	public class FeaturedReview
	{
		[JsonProperty("id")]
		public int Id { get; private set; }

		[JsonProperty("currentJob")]
		public string CurrentJob { get; private set; }

		[JsonProperty("reviewDateTime")]
		public DateTime ReviewDateTime { get; private set; }

		[JsonProperty("jobTitle")]
		public string JobTitle { get; private set; }

		[JsonProperty("location")]
		public string Location { get; private set; }

		[JsonProperty("headline")]
		public string Headline { get; private set; }

		[JsonProperty("pros")]
		public string Pros { get; private set; }

		[JsonProperty("cons")]
		public string Cons { get; private set; }
	}
}