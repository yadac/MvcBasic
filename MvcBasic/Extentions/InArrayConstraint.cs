using System.Linq;
using System.Web;
using System.Web.Routing;

namespace MvcBasic.Extentions
{
    public class InArrayConstraint : IRouteConstraint
    {
        private string[] _elems = null;

        public InArrayConstraint(string elems)
        {
            _elems = elems.Split(',');
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            if (values.TryGetValue(parameterName, out var elem))
            {
                return _elems.Contains(elem);
            }

            return false;
        }
    }
}