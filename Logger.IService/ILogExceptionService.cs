﻿using Logger.Common;
using Logger.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.IService
{
    public interface ILogExceptionService : IDependency
    {
        void Save(LogException logException,ExceptionInfo exceptionInfo);
    }
}
