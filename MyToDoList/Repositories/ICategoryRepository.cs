using MyToDoList.Data;
using MyToDoList.Tables;
using System.Collections.Generic;

namespace MyToDoList.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetCategories();
        bool IsCategoryAvailable(int categoryID);
    }
}
