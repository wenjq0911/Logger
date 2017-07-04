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
    public class LogExceptionService : ILogExceptionService
    {
        public ILogExceptionDao LogExceptionDao { get; set; }
        public IExceptionInfoDao ExceptionInfoDao { get; set; }
        [Transaction]
        public void Save(LogException logException, ExceptionInfo exceptionInfo)
        {
            ExceptionInfoDao.Insert(exceptionInfo);
            LogExceptionDao.Insert(logException);
        }
    }
}
