using System;
using System.Runtime.Serialization;

namespace Janglin.Glassdoor.Client
{
    [Serializable]
    internal class GlassdoorException : Exception
    {
        private Response<JobsStats> json;
        private Response<JobsProgression> json1;

        public GlassdoorException()
        {
        }

        public GlassdoorException(Response<JobsProgression> json1)
        {
            this.json1 = json1;
        }

        public GlassdoorException(string message) : base(message)
        {
        }

        public GlassdoorException(Response<JobsStats> json)
        {
            this.json = json;
        }

        public GlassdoorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GlassdoorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}