using System;

namespace Janglin.GlassDoor.Api
{
	[Serializable]
	public class GlassDoorException : Exception
	{
		public GlassDoorException(Response jsonResponse)
		{
			Success = jsonResponse.Success;
			Status = jsonResponse.Status;
		}

		public string Status { get; private set; }
		public bool Success { get; private set; }
	}
}