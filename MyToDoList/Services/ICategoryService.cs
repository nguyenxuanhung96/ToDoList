using MyToDoList.Models;
using System.Collections.Generic;

namespace MyToDoList.Services
{
    public interface ICategoryService
    {
        bool AddNew(string name, int createBy);
        bool Update(int id, string name, int createBy);
        bool Delete(int id, int createBy);
        IEnumerable<CategoryModel> GetCategories();
    }
}
