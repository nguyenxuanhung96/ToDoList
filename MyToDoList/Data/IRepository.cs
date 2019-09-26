using System.Collections.Generic;

namespace MyToDoList.Data
{
    public interface IRepository<T> where T : class
    {
        void Insert(T entity);
        void InsertMany(IEnumerable<T> entities);
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Delete(T entity);
        void DeleteMany(IEnumerable<T> entities);
        /// <summary>
        /// Already committed
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);
        void UpdateMany(IEnumerable<T> entities);
        int Commit();
    }
}
