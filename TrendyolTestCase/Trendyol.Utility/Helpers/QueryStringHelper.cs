using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace Trendyol.Utility.Helpers
{
    public static class QueryStringHelper
    {
        public static string toQueryString(this NameValueCollection nvc)
        {
            var array = (
                from key in nvc.AllKeys
                from value in nvc.GetValues(key)
                select string.Format(
            "{0}={1}",
            HttpUtility.UrlEncode(key),
            HttpUtility.UrlEncode(value))
                ).ToArray();
            return array.Length == 0 ? string.Empty : "?" + string.Join("&", array);
        }
    }
}