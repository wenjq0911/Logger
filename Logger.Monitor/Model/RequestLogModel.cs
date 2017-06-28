using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Monitor.Model
{
    public class RequestLogModel
    {
        public string uuid { get; set; }
        public string ip { get; set; }
        public string area { get; set; }
        public string controller { get; set; }
        public string action { get; set; }
        public string type { get; set; }
        public string param_url { get; set; }
        public string param_body { get; set; }
        public string param_form { get; set; }
        public int action_ms { get; set; }
        public int render_ms { get; set; }
        public string logger_time { get; set; }
        public int is_exception { get; set; }
    }
}
