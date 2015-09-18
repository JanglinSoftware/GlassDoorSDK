using System;
using System.Collections;
using System.Collections.Generic;

namespace Janglin.Glassdoor.Client
{
	internal class PageResultEnumerator<T> : IEnumerator<T> where T : class
	{
		IEnumerator<T> _InternalEnumerator;

		public PageResultEnumerator(int pageNumber, int pageSize)
		{
			_WebResponseTask = WebRequester.GetAsync<CompanySearchResult>

		}

		public T Current
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		object IEnumerator.Current
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public bool MoveNext()
		{
			if(_InternalEnumerator==null)
			{

			}

			throw new NotImplementedException();
		}

		public void Reset()
		{
			throw new NotImplementedException();
		}
	}
}