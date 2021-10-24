using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Hahn.ApplicationProcess.July2021.Data.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicationProcess.July2021.Data.Implementations
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal ApplicationProcessDbContext DbContext;
        internal DbSet<TEntity> DbSet;

        public GenericRepository(ApplicationProcessDbContext dbContext)
        {
            this.DbContext = dbContext;
            this.DbSet = dbContext.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, property) => current.Include(property));

            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }

        public virtual TEntity Insert(TEntity entity)
        {
            DbSet.Add(entity);

            return entity;
        }

        public virtual void Delete(object id)
        {
            var entity = DbSet.Find(id);
            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (DbContext.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            DbContext.Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
