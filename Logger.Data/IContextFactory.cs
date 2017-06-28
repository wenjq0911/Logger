using Chloe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Data.Interface
{
    public enum DbType
    {
        MySql,
        SqlServer,
        //Oracle,
        //SqLite
    }
    public interface IContextFactory
    {
        IDbContext CreateContext(DbType type);
    }
}
