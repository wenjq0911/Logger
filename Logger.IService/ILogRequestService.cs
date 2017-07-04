using Logger.Common;
using Logger.Data.Interface;
using Logger.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.IService
{
    public interface ILogRequestService : IBaseService<LogRequest>,IDependency
    {
        void SaveAll(LogRequest lofRequest,RequestInfo requestInfo,HostInfo hostInfo);
    }
}
