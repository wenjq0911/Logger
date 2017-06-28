using Chloe;
using Chloe.MySql;
using Chloe.SqlServer;
using Logger.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Data
{
    public class ContextFactory : IContextFactory
    {
        private string _conn { get; set; }
        public ContextFactory(string conn)
        {
            this._conn = conn;
        }
        public IDbContext CreateContext(DbType type)
        {
            IDbContext context = null;
            switch (type)
            {
                case DbType.MySql:
                    context = new MySqlContext(new MysqlConnectionFactory(this._conn));
                    break;
                case DbType.SqlServer:
                    context = new MsSqlContext(this._conn);
                    break;
            }
            return context;
        }
    }
}
