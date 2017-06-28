using Logger.Data;
using Logger.Data.Interface;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Data
{
    [Serializable]
    public class TransactionAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            DbSession.session.BeginTransaction();
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            DbSession.session.CommitTransaction();
        }

        public override void OnException(MethodExecutionArgs args)
        {
            DbSession.session.RollbackTransaction();
            base.OnException(args);
        }
    }
}
