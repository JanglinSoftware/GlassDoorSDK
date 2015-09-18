using System;
using System.Collections;
using System.Collections.Generic;

namespace Janglin.Glassdoor.Client
{
	internal class PagedResult<T> : Result<T>, IEnumerable<T> where T :class
	{
		string _Url;

		public PagedResult(string url)
		{
			_Url = url;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return new PageResultEnumerator<T>();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new PageResultEnumerator<T>();
		}
	}
}