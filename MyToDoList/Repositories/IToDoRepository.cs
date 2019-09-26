using MyToDoList.Data;
using MyToDoList.Tables;
using System.Collections.Generic;

namespace MyToDoList.Repositories
{
    public interface IToDoRepository : IRepository<ToDo>
    {
        IEnumerable<ToDo> GetAllToDos();
    }
}
