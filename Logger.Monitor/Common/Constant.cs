using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Monitor
{
    public class Constant
    {
        public const string ACTIVE_MQ_HOST = "ActiveMQHost";
        public const string LOGGER_OPT_MQ_NAME = "OPTLOGGER";
        public const string LOGGER_REQUEST_MQ_NAME = "REQUESTLOGGER";
        public const string LOGGER_EXCEPTION_MQ_NAME = "EXCEPTIONLOGGER";
        internal const string PREFIX_KEY = "__wach__";
        internal const string NAME_KEY_ACTION = "action";
        internal const string NAME_KEY_RENDER = "render";
    }
}
