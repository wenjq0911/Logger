using Logger.Common;
using Logger.Data.Interface;
using Logger.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.IDao
{
    public interface ILogOperationDao : IBaseDao<LogOperation>, IDependency
    {
    }
}
