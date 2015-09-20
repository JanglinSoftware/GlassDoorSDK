using System;
using System.Collections;
using System.Collections.Generic;

namespace Janglin.Glassdoor.Api
{
    internal class PagedResult<C, I> : Result<C>, IEnumerable<I>
        where C : PagedTypedResponse<I>, IEnumerable<I>
        where I : class
    {
        string _Url;
        int _PageSize = 50;
        int _PageNumber = 0;

        public PagedResult(string url)
        {
            _Url = url;
        }

        public IEnumerator<I> GetEnumerator()
        {
            return new PageResultEnumerator<C,I>(_Url,_PageNumber, _PageSize);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new PageResultEnumerator<C, I>(_Url,_PageNumber, _PageSize);
        }
    }
}