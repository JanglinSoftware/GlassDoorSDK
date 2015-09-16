using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janglin.RestApiSdk.Json
{
	public class Request : Janglin.RestApiSdk.Request
	{
		protected internal override byte[] ByteArrayBuffer
		{
			get
			{
				throw new NotImplementedException();
			}
		}
	}
}
