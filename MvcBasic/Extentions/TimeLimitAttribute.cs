using System;
using System.Web.Mvc;

namespace MvcBasic.Extentions
{
    public class TimeLimitAttribute : FilterAttribute, IAuthorizationFilter
    {
        private DateTime _begin = DateTime.MinValue;
        private DateTime _end = DateTime.MaxValue;

        public string Begin
        {
            set
            {
                var b = DateTime.Parse(value);
                if (b >= this._end) throw new ArgumentException("Begin parameter is invalid");
                this._begin = b;
            }
        }
        public string End
        {
            set
            {
                var e = DateTime.Parse(value);
                if (e <= this._begin) throw new ArgumentException("End parameter is invalid");
                this._end = e;
            }
        }


        public TimeLimitAttribute(string begin, string end)
        {
            this.Begin = begin;
            this.End = end;
        }


        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null) throw new ArgumentException("filtercontext");

            var current = DateTime.Now;
            if (current < this._begin || current > this._end)
            {
                var message = $"このページは {this._begin.ToLongDateString()} から {this._end.ToLongDateString()} までの期間のみ有効です";
                throw new TimeLimitException(message);
            }
        }
    }

    [Serializable]
    public class TimeLimitException : Exception
    {
        public TimeLimitException(string message) : base(message)
        {
        }
    }
}