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
        IDbContext DbContext { get; set; }
        public Db()
        {
            this.DbContext = Logger.Data.DbContext.GetContext();
            DbSession.session = this.DbContext.Session;
        }

        public IDbSession Session
        {
            get
            {
                return DbContext.Session;
            }
        }

        public int Delete(Expression<Func<T, bool>> condition)
        {
            return DbContext.Delete<T>(condition);
        }

        public int Delete(T entity)
        {
            return DbContext.Delete<T>(entity);
        }

        public int DeleteByKey(object key)
        {
            return DbContext.DeleteByKey<T>(key);
        }

        public void Dispose()
        {
            DbSession.session = null;
            DbContext.Dispose();
        }

        public object Insert(Expression<Func<T>> body)
        {
            return DbContext.Insert<T>(body);
        }

        public T Insert(T entity)
        {
            return DbContext.Insert<T>(entity);
        }

        public IQuery<T> Query()
        {
            return DbContext.Query<T>();
        }

        public T QueryByKey(object key, bool tracking = false)
        {
            return DbContext.QueryByKey<T>(key, tracking);
        }

        public IEnumerable<T1> SqlQuery<T1>(string sql, params DbParam[] parameters) where T1 : new()
        {
            return DbContext.SqlQuery<T1>(sql, parameters);
        }

        public IEnumerable<T1> SqlQuery<T1>(string sql, CommandType cmdType, params DbParam[] parameters) where T1 : new()
        {
            return DbContext.SqlQuery<T1>(sql, cmdType, parameters);
        }

        public void TrackEntity(object entity)
        {
            DbContext.TrackEntity(entity);
        }

        public int Update(T entity)
        {
            return DbContext.Update<T>(entity);
        }

        public int Update(Expression<Func<T, bool>> condition, Expression<Func<T, T>> body)
        {
            return DbContext.Update<T>(condition, body);
        }

        
    }
}
