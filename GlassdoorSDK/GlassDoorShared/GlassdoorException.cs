﻿using System;

namespace Janglin.Glassdoor.Api
{
	public class GlassdoorException : Exception
	{
		public GlassdoorException(Response jsonResponse)
		{
			Success = jsonResponse.Success;
			Status = jsonResponse.Status;
		}

		public string Status { get; private set; }
		public bool Success { get; private set; }
	}
}