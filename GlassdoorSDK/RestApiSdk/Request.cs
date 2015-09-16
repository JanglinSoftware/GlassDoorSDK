using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janglin.RestApiSdk
{
	public abstract class Request
	{
		protected internal abstract byte[] ByteArrayBuffer { get; }
	}
}