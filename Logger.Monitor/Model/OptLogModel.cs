using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Monitor
{
    public class OptLogModel
    {
        public string uuid { get; set; }
        public string log_time { get; set; }
        public string logger_request_uuid { get; set; }
        public string remark { get; set; }
        public int type { get; set; }
    }
}
