using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.DAL;
using System.Linq.Expressions;

namespace OA.BLL
{
    public class BaseBLL<T> where T : class,new()
    {
        private readonly BaseDAL<T> dal = new BaseDAL<T>();
        /// <summary>
        /// Load Entity
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(Expression<Func<T,bool>> whereLambda)
        {
            return dal.LoadEntities(whereLambda);
        }

        /// <summary>
        /// Load By Page
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderByLambda"></param>
        /// <param name="IsArc">tru, arc; false, desc</param>
        /// <returns></returns>
        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T,bool>> whereLambda, Expression<Func<T,s>> orderByLambda, bool IsArc)
        {
            return dal.LoadPageEntities(pageIndex, pageSize, out totalCount, whereLambda, orderByLambda, IsArc);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {
            return dal.DeleteEntity(entity);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateEntity(T entity)
        {
            return dal.UpdateEntity(entity);
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T InsertEntity(T entity)
        {
            return dal.InsertEntity(entity);
        }
    }
}
