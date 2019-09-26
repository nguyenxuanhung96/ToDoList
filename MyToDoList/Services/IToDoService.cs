using MyToDoList.Models;
using MyToDoList.Models.Commons;
using System.Collections.Generic;

namespace MyToDoList.Services
{
    public interface IToDoService
    {
        IEnumerable<ToDoModel> GetListToDos();
        bool AddToDo(string title, string content, int status, int categoryId, int createBy);
        ResponseBaseModel EditToDo(int toDoId, string title, string content, int status, int categoryId, int createBy);
        bool FinishToDo(int toDoID);
    }
}
