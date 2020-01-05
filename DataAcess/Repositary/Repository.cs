using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using DataAcess.Models;

namespace BillPaymentDataAccess.Repositary
{
    public class Repository<TEntity>:  IRepository<TEntity> where TEntity : class
     {
        // variables hold the database context and entity set
        // for the entity type that the instance of the repo
        internal DbContext _context;
    internal DbSet<TEntity> _dbSet;
    public Repository(paymentsContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    /// <summary>
    /// Allows you to query an entity
    /// </summary>
    /// <param name="filter">Lambda expression for filtering rows</param>
    /// <param name="orderBy">Lambda expression for sorting</param>
    /// <param name=" includedProperties">Add an argument for each
    ///  property that should be eager loaded</param>
    /// <param name="page">When pageSize is greater than 0 then will return
    ///   a particular data page</param>
    /// <param name="pageSize">Number of items per page.
    ///   0 will return all data without pages</param>
    /// <returns>An IEnumerable of the type or null if no data is found</returns>
    public virtual IEnumerable<TEntity> Query(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        int page = 1,
        int pageSize = 0,
        params Expression<Func<TEntity, object>>[] includedProperties)
    {
        IQueryable<TEntity> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }
        foreach (var includeProperty in includedProperties)
        {
            query.Include(includeProperty);
        }

        if (pageSize > 0)
        {
            query = query.Take(pageSize).Skip((page - 1) * pageSize);
        }

        if (orderBy != null)
        {
            return orderBy(query).ToList();
        }
        else
        {
            return query.ToList();
        }
    }

    /// <summary>
    /// Gets the first entity an object as key
    /// </summary>
    /// <param name="key">The key of the object you are looking for</param>
    /// <returns>An instance of the entity or null</returns>
    public virtual TEntity GetEntityByKey(object key)
    {
        return _dbSet.Find(key);
    }

    /// <summary>
    /// Insert a new entity
    /// </summary>
    /// <param name="entity">Entity you would like to add</param>
    public virtual void Insert(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entityToUpdate">Entity that you would like to update</param>
    public virtual void Update(TEntity entityToUpdate)
    {
        _dbSet.Attach(entityToUpdate);
        _context.Entry(entityToUpdate).State = EntityState.Modified;
    }

    /// <summary>
    /// Delete the entity
    /// </summary>
    /// <param name="entityToDelete">Entity that you wish to delete</param>
    public virtual void Delete(TEntity entityToDelete)
    {
        _context.Remove(entityToDelete);
    }
}
}
