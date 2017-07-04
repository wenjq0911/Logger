using Chloe;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Data.Interface
{
    public interface IBaseService<T>
    {
        int Delete(Expression<Func<T, bool>> condition);

        int Delete(T entity);

        int DeleteByKey(object key);

        object Insert(Expression<Func<T>> body);

        T Insert(T entity);

        IQuery<T> Query();

        T QueryByKey(object key, bool tracking = false);

        IEnumerable<T1> SqlQuery<T1>(string sql, params DbParam[] parameters) where T1 : new();

        IEnumerable<T1> SqlQuery<T1>(string sql, CommandType cmdType, params DbParam[] parameters) where T1 : new();

        void TrackEntity(object entity);

        int Update(T entity);

        int Update(Expression<Func<T, bool>> condition, Expression<Func<T, T>> body);
        IQuery<T> Query(Expression<Func<T, bool>> condition);
        IQuery<T> QueryByPage<S>(int page, int size, out long count, Expression<Func<T, bool>> where = null, Expression<Func<T, S>> order = null,bool asc=true);

    }
}
