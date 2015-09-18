using System;
using System.Runtime.Serialization;

namespace Janglin.Glassdoor.Client
{
	[Serializable]
	public class GlassdoorException<T> : Exception
	{
		public GlassdoorException(Response<T> json){ }

		public GlassdoorException(){ }

		public GlassdoorException(Response<JobsProgression> json1){ }

		public GlassdoorException(string message) : base(message){ }

		public GlassdoorException(string message, Exception innerException) : base(message, innerException){ }

		protected GlassdoorException(SerializationInfo info, StreamingContext context) : base(info, context){ }
	}
}