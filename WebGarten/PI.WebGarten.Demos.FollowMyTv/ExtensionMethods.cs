using System.Collections.Generic;
using System.Linq;

namespace PI.WebGarten.Demos.FollowMyTv
{
    public static class ExtensionMethods
    {
        public static string GetValue(this IEnumerable<KeyValuePair<string, string>> content, string key)
        {
            return content.Where( p => p.Key.Equals( key ) ).Select( p => p.Value ).FirstOrDefault();
        }
    }
}
