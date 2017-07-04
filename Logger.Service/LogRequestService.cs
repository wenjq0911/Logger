using Logger.Common;
using Logger.Data;
using Logger.Domain;
using Logger.IDao;
using Logger.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Service
{
    public class LogRequestService : BaseService<LogRequest>,ILogRequestService
    {
        public ILogRequestDao LogRequestDao { get; set; }
        public IRequestInfoDao RequestInfoDao { get; set; }
        public IHostInfoDao HostInfoDao { get; set; }

        [Transaction]
        public void SaveAll(LogRequest logRequest, RequestInfo requestInfo, HostInfo hostInfo) {
            var hosts = HostInfoDao.Query().Where(m => m.IP.Equals(hostInfo.IP)).ToList();
            if (hosts.Count == 0)
            {
                HostInfoDao.Insert(hostInfo);
            }
            else {
                logRequest.HostUuid = hosts.First().Uuid;
            }
            RequestInfoDao.Insert(requestInfo);
            LogRequestDao.Insert(logRequest);
        }

    }
}
