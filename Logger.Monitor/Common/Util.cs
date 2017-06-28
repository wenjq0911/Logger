using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Monitor
{
    internal class Util
    {
        public static string ConvertNameValueCollection(NameValueCollection value) {
            return JsonConvert.SerializeObject(value.ToDictionary());
        }
    }

    internal static class NVCExtender
    {
        internal static IDictionary<string, string> ToDictionary(
                                            this NameValueCollection source)
        {
            return source.AllKeys.ToDictionary(k => k, k => source[k]);
        }
    }
}
