using MyToDoList.Models;
using MyToDoList.Repositories;
using MyToDoList.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyToDoList.Services.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(
            ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public bool AddNew(string name, int createBy)
        {
            try
            {
                _categoryRepository.Insert(Category.Create(name, 1));
                _categoryRepository.Commit();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id, int createBy)
        {
            try
            {
                var category = _categoryRepository.GetById(id);
                if(category != null && !category.IsDeleted)
                {
                    category.IsDeleted = true;
                    _categoryRepository.Update(category);
                }
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<CategoryModel> GetCategories()
        {
            var result = _categoryRepository.GetCategories().Select(c => new CategoryModel
            {
                categoryID = c.CategoryID,
                categoryName = c.CategoryName,
                createAt = c.CreatedAt,
                createBy = c.CreatedBy.ToString(),
                updateAt = c.UpdatedAt,
            }).ToList();
            return result;
        }

        public bool Update(int id, string name, int createBy)
        {
            try
            {
                var category = _categoryRepository.GetById(id);
                if (category != null)
                {
                    category.CategoryName = name;
                    category.CreatedBy = createBy;
                    _categoryRepository.Update(category);
                }
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
    }
}
