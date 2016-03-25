using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.Moel;
using System.Linq.Expressions;

namespace OA.DAL
{
    public class BaseDAL<T> where T: class,new()
    {
        /// <summary>
        /// Load Entity
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(Expression<Func<T,bool>> whereLambda)
        {
            using(var dbcontext = new OAEntities())
            {
                return dbcontext.Set<T>().Where<T>(whereLambda);
            }
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
            using(var dbcontext = new OAEntities())
            {
                var temp = dbcontext.Set<T>().Where<T>(whereLambda);
                totalCount = temp.Count();
                if(IsArc)
                {
                    temp = temp.OrderBy<T, s>(orderByLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
                }
                else
                {
                    temp = temp.OrderByDescending<T, s>(orderByLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
                }
                return temp;
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {
            using(var dbcontext = new OAEntities())
            {
                dbcontext.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
                return dbcontext.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateEntity(T entity)
        {
            using(var dbcontext = new OAEntities())
            {
                dbcontext.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
                return dbcontext.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T InsertEntity(T entity)
        {
            using(var dbcontext = new OAEntities())
            {
                dbcontext.Set<T>().Add(entity);
                dbcontext.SaveChanges();
                return entity;
            }
        }
    }
}
