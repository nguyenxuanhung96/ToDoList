using MyToDoList.Contexts;
using MyToDoList.Data;
using MyToDoList.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyToDoList.Repositories.Implements
{
    public class ToDoRepository : BaseRepositoryService<ToDoListDataContext, ToDo>, IToDoRepository
    {
        public ToDoRepository(IDaoFactory daoFactory) : base(daoFactory.GetDataContext())
        {
        }

        public IEnumerable<ToDo> GetAllToDos()
        {
            IEnumerable<ToDo> result = GetAll().Where(t => !t.IsDeleted).ToList();
            return result;
        }

        public override void Insert(ToDo entity)
        {
            PrepareForAdd(entity);
            base.Insert(entity);
        }
        public override void InsertMany(IEnumerable<ToDo> entities)
        {
            foreach (var entity in entities)
            {
                PrepareForAdd(entity);
            }
            base.InsertMany(entities);
        }

        public override void Update(ToDo entity)
        {
            PrepareForUpdate(entity);
            base.Update(entity);
        }

        public override void UpdateMany(IEnumerable<ToDo> entities)
        {
            foreach (var entity in entities)
            {
                PrepareForUpdate(entity);
            }
            base.UpdateMany(entities);
        }

        private void PrepareForAdd(ToDo entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
        }
        private void PrepareForUpdate(ToDo entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
        }
    }
}
