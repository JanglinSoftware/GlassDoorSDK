using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Janglin.Glassdoor.Api
{
    internal class PageResultEnumerator<C, I> : IEnumerator<I>
        where C : PagedTypedResponse<I>, IEnumerable<I>
        where I : class
    {
        IEnumerator<I> _InternalEnumerator;
        private Task<C> _WebResponseTask;
        private string _Url;
        int _PageSize = 50;
        int _PageNumber = 1;
        bool IsLastPage;

        public PageResultEnumerator(string url, int pageNumber, int pageSize)
        {
            _Url = url;
            _PageSize = pageSize;
            _PageNumber = pageNumber;
            _WebResponseTask = WebRequester.GetAsync<C>(GetUrl());

        }

        private string GetUrl()
        {
            return String.Format(_Url, _PageNumber, _PageSize);
        }

        public I Current
        {
            get
            {
                return _InternalEnumerator.Current;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return _InternalEnumerator.Current;
            }
        }

        public void Dispose()
        {
            if (_InternalEnumerator != null)
                _InternalEnumerator.Dispose();
        }

        public bool MoveNext()
        {
            if (_InternalEnumerator == null)
            {
                if (IsLastPage) return false;

                _WebResponseTask.Wait();
                var result = _WebResponseTask.Result;

                _InternalEnumerator = result.GetEnumerator();
                _WebResponseTask = null;

                if (result.CurrentPageNumber < result.TotalNumberOfPages)
                {
                    _PageNumber = result.CurrentPageNumber + 1;
                    _WebResponseTask = WebRequester.GetAsync<C>(GetUrl());
                }
                else
                    IsLastPage = true;
            }

            if (!_InternalEnumerator.MoveNext())
            {
                _InternalEnumerator = null;
                return MoveNext();
            }
            else
                return true;
        }

        public void Reset()
        {
            if (_InternalEnumerator != null)
            {
                _InternalEnumerator.Dispose();
                _InternalEnumerator = null;
            }
        }
    }
}