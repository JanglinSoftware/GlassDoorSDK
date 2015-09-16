using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janglin.RestApiSdk.Json
{
	public abstract class Response : Janglin.RestApiSdk.Response
	{

		const string _ContentType = "application/xml";
		const string _Accept = "application/xml";

		protected override string Accept { get { return _ContentType; } }

		protected override string ContentType { get { return _Accept; } }
	}
}