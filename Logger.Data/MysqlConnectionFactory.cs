using Chloe.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Logger.Data
{
    public class MysqlConnectionFactory : IDbConnectionFactory
    {
        string _connection = null;
        public MysqlConnectionFactory(string connection)
        {
            this._connection = connection;
        }
        public IDbConnection CreateConnection()
        {
            return new MySqlConnection(this._connection);
        }
    }
}
