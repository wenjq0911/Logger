using Logger.Common;
using Logger.IDao;
using Logger.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Service
{
    public class RequestInfoService : IRequestInfoService
    {
        public IRequestInfoDao RequestInfoDao { get; set; }
    }
}
