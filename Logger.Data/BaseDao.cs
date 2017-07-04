using Chloe;
using Logger.Data.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Data
{
    public class BaseDao<T>
    {
        protected Db<T> _db { get; set; }

        public BaseDao()
        {
            _db = new Db<T>();
        }

        public IDbSession Session
        {
            get
            {
                return _db.DbContext.Session;
            }
        }

        public int Delete(Expression<Func<T, bool>> condition)
        {
            return _db.DbContext.Delete<T>(condition);
        }

        public int Delete(T entity)
        {
            return _db.DbContext.Delete<T>(entity);
        }

        public int DeleteByKey(object key)
        {
            return _db.DbContext.DeleteByKey<T>(key);
        }

        public void Dispose()
        {
            DbSession.session = null;
            _db.DbContext.Dispose();
        }

        public object Insert(Expression<Func<T>> body)
        {
            return _db.DbContext.Insert<T>(body);
        }

        public T Insert(T entity)
        {
            return _db.DbContext.Insert<T>(entity);
        }

        public IQuery<T> Query()
        {
            return _db.DbContext.Query<T>();
        }

        public T QueryByKey(object key, bool tracking = false)
        {
            return _db.DbContext.QueryByKey<T>(key, tracking);
        }

        public IEnumerable<T1> SqlQuery<T1>(string sql, params DbParam[] parameters) where T1 : new()
        {
            return _db.DbContext.SqlQuery<T1>(sql, parameters);
        }

        public IEnumerable<T1> SqlQuery<T1>(string sql, CommandType cmdType, params DbParam[] parameters) where T1 : new()
        {
            return _db.DbContext.SqlQuery<T1>(sql, cmdType, parameters);
        }

        public void TrackEntity(object entity)
        {
            _db.DbContext.TrackEntity(entity);
        }

        public int Update(T entity)
        {
            return _db.DbContext.Update<T>(entity);
        }

        public int Update(Expression<Func<T, bool>> condition, Expression<Func<T, T>> body)
        {
            return _db.DbContext.Update<T>(condition, body);
        }

        public IQuery<T> Query(Expression<Func<T, bool>> condition) {
            return _db.DbContext.Query<T>().Where(condition);
        }

        public IQuery<T> QueryByPage<S>(int page, int size, out long count, Expression<Func<T, bool>> where = null, Expression<Func<T, S>> order = null,bool asc=true) {
            count = _db.DbContext.Query<T>().Count();
            if (asc)
                return _db.DbContext.Query<T>().Where(where).OrderBy(order).TakePage(page,size);
            else
                return _db.DbContext.Query<T>().Where(where).OrderByDesc(order).TakePage(page, size);
        }

    }
}
