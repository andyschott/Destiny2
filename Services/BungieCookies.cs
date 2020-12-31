using System.Collections.Generic;
using System.Linq;

namespace Destiny2.Services
{
    public class BungieCookies
    {
        public IEnumerable<(string name, string value)> Cookies { get; set; } =
            Enumerable.Empty<(string, string)>();

        internal void SetCookies(IEnumerable<string> values)
        {
            Cookies = values.Select(cookie =>
            {
                var index = cookie.IndexOf('=');
                if(index == -1)
                {
                    return (null, null);

                }
                var name = cookie.Substring(0, index);
                var value = cookie.Substring(index + 1);

                return (name, value);
            }).Where(cookie => cookie.name != null)
            .ToArray();
        }
    }
}