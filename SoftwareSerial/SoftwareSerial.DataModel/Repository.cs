using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;

namespace SoftwareSerial.DataModel
{
    public class SortExpression<TEntity, TType>
    {
        Expression<Func<TEntity, TType>> SortProperty;
    }

    public class Repository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
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

        public virtual TEntity GetByID(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual TEntity Attach(TEntity entity)
        {
            return _dbSet.Attach(entity);
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void DeleteCascade(Expression<Func<TEntity,bool>> filter,string includeProperties)
        {
            var query = _dbSet.Where(filter);

            foreach (var includeProperty in includeProperties.Split(new[]{','},StringSplitOptions.RemoveEmptyEntries))
            {
                query.Include(includeProperty);
            }

            Delete(query.First());
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            SetEntityState(entityToDelete, EntityState.Deleted);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            SetEntityState(entityToUpdate, EntityState.Modified);
        }

        public virtual IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters)
        {
            return _dbSet.SqlQuery(query, parameters).ToList();
        }

        public virtual void SetEntityState(TEntity entity, EntityState entityState)
        {
            _dbContext.Entry(entity).State = entityState;
        }
    }
}