using Logger.Common;
using Logger.IDao;
using Logger.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Domain;
using Logger.Data;

namespace Logger.Service
{
    public class LogOperationService : ILogOperationService
    {
        public ILogOperationDao LogOperationDao { get; set; }
        public IOperationInfoDao OperationInfoDao { get; set; }
        [Transaction]
        public void Save(OperationInfo operation_info, LogOperation log_operation)
        {
            OperationInfoDao.Insert(operation_info);
            LogOperationDao.Insert(log_operation);
        }
    }
}
