using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MyToDoList.Data
{
    public class BaseRepositoryService<TC, T> : IRepository<T> 
        where TC : DbContext
        where T : class
    {
        private DbSet<T> _entities;

        public BaseRepositoryService(TC dataContext)
        {
            Context = dataContext;
        }

        public TC Context { get; set; }

        protected DbSet<T> Entities
        {
            get { return _entities ?? (_entities = Context.Set<T>()); }
        }

        public int Commit()
        {
            return Context.SaveChanges();
        }

        public virtual void Insert(T entity)
        {
            Entities.Add(entity);
        }

        public virtual void InsertMany(IEnumerable<T> entities)
        {
            Entities.AddRange(entities);
            Commit();
        }

        public IEnumerable<T> GetAll()
        {
            return Entities.AsQueryable();
        }

        public T GetById(object id)
        {
            return Entities.Find(id);
        }

        public void Delete(T entity)
        {
            Entities.Remove(entity);
        }

        public void DeleteMany(IEnumerable<T> entities)
        {
            Entities.RemoveRange(entities);
            Commit();
        }

        public virtual void Update(T entity)
        {
            Entities.Update(entity);
            Commit();
        }

        public virtual void UpdateMany(IEnumerable<T> entities)
        {
            Entities.UpdateRange(entities);
            Commit();
        }
    }
}
