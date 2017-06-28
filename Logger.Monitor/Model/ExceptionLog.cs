using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Monitor.Model
{
    public class ExceptionLog
    {
        public string uuid { get; set; }
        public string type { get; set; }
        public string message { get; set; }
        public string stack_trace { get; set; }
        public string source { get; set; }
        public string log_request_uuid { get; set; }
        public string log_time { get; set; }
    }
}
