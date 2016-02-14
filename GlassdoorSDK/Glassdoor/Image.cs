using Newtonsoft.Json;

namespace Janglin.GlassDoor.Api
{
	public class Image
	{
		[JsonProperty("src")]
		public string Source { get; private set; }

		[JsonProperty("height")]
		public string Height { get; private set; }

		[JsonProperty("width")]
		public string Width { get; private set; }

		public override bool Equals(object obj)
		{
			var input = obj as Image;

			if (input == null)
				return false;
			else {
				return input.Source.Equals(Source)
					&& input.Height.Equals(Height)
					&& input.Width.Equals(Width);
			}
		}

		public override int GetHashCode()
		{
			return Source.GetHashCode()
				^ Height.GetHashCode()
				^ Width.GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("{0} ({1}x{2})", Source, Height, Width);
		}
	}
}