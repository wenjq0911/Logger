using Chloe;
using Logger.Data.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Data
{
    public class DbContext
    {
        private static IDbContext db_context = null;

        private DbContext() { }

        public static IDbContext GetContext() {
            if (db_context == null) {
                var conn = ConfigurationManager.ConnectionStrings["DbConnectionStr"];
                db_context = new ContextFactory(conn.ConnectionString
                ).CreateContext(GetDbType(conn.ProviderName));
            }
            return db_context;
        }

        private static DbType GetDbType(string name)
        {
            name = name.ToLower();
            switch (name)
            {
                case "system.data.sqlclient":
                    return DbType.SqlServer;
                case "mysql.data.mysqlclient":
                    return DbType.MySql;
                default:
                    throw new Exception("不支持的数据库类型");
            }
        }

    }
}
