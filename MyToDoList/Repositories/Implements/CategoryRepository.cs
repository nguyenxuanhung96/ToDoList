using MyToDoList.Contexts;
using MyToDoList.Data;
using MyToDoList.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyToDoList.Repositories.Implements
{
    public class CategoryRepository : BaseRepositoryService<ToDoListDataContext, Category>, ICategoryRepository
    {
        public CategoryRepository(IDaoFactory daoFactory) : base(daoFactory.GetDataContext())
        {
        }

        public IEnumerable<Category> GetCategories()
        {
            return GetAll().Where(c => !c.IsDeleted).AsEnumerable();
        }

        public override void Insert(Category entity)
        {
            PrepareaForAdd(entity);
            base.Insert(entity);
        }
        public override void InsertMany(IEnumerable<Category> entities)
        {
            foreach (var entity in entities)
            {
                PrepareaForAdd(entity);
            }
            base.InsertMany(entities);
        }

        public bool IsCategoryAvailable(int categoryID)
        {
            var category = GetById(categoryID);
            return category != null && !category.IsDeleted;
        }

        public override void Update(Category entity)
        {
            PrepareaForUpdate(entity);
            base.Update(entity);
        }
        public override void UpdateMany(IEnumerable<Category> entities)
        {
            foreach (var entity in entities)
            {
                PrepareaForUpdate(entity);
            }
            base.UpdateMany(entities);
        }

        private void PrepareaForAdd(Category entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
        }
        private void PrepareaForUpdate(Category entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
        }
    }
}
