using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BillPaymentDataAccess.Repositary
{
    /// <summary>
    /// The IRepository
    /// </summary>
    /// <typeparam name="TEntity">The TEntity</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Delete the entity
        /// </summary>
        /// <param name="entityToDelete">Entity that you wish to delete</param>
        void Delete(TEntity entityToDelete);

        /// <summary>
        /// Gets the first entity an object as key
        /// </summary>
        /// <param name="key">The key of the object you are looking for</param>
        /// <returns>An instance of the entity or null</returns>
        TEntity GetEntityByKey(object key);

        /// <summary>
        /// Insert a new entity
        /// </summary>
        /// <param name="entity">Entity you would like to add</param>
        void Insert(TEntity entity);
        IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null,
                      Func<IQueryable<TEntity>,
                      IOrderedQueryable<TEntity>> orderBy = null,
                      int page = 1,
                      int pageSize = 0,
                      params Expression<Func<TEntity, object>>[] includedProperties);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entityToUpdate">Entity that you would like to update</param>
        void Update(TEntity entityToUpdate);
    }
}
