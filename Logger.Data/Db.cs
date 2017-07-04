using Chloe;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Data
{
    public class Db<T>
    {
        public IDbContext DbContext { get; set; }
        public Db()
        {
            this.DbContext = Logger.Data.DbContext.GetContext();
            DbSession.session = this.DbContext.Session;
        }
    }
}
