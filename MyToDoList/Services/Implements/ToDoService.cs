using System;
using System.Collections.Generic;
using System.Linq;
using MyToDoList.Commons;
using MyToDoList.Models;
using MyToDoList.Models.Commons;
using MyToDoList.Repositories;
using MyToDoList.Tables;

namespace MyToDoList.Services.Implements
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _toDoRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ToDoService(
            IToDoRepository toDoRepository
            , ICategoryRepository categoryRepository)
        {
            _toDoRepository = toDoRepository;
            _categoryRepository = categoryRepository;
        }

        public bool AddToDo(string title, string content, int status, int categoryId, int createBy)
        {
            try
            {
                if (_categoryRepository.IsCategoryAvailable(categoryId))
                {
                    _toDoRepository.Insert(ToDo.Create(title, content, status, categoryId, createBy));
                    _toDoRepository.Commit();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;  
            }
        }

        public ResponseBaseModel DeleteToDo(int toDoId, int createBy)
        {
            try
            {
                var toDo = _toDoRepository.GetById(toDoId);
                if(toDo != null)
                {
                    toDo.IsDeleted = true;
                    _toDoRepository.Update(toDo);
                    return ResponseBaseModel.Success("Delete successfully");
                }
                return ResponseBaseModel.Success("ToDo not found!");
            }catch(Exception ex)
            {
                return ResponseBaseModel.Failed(ex.Message);
            }
        }

        public ResponseBaseModel EditToDo(int toDoId, string title, string content, int status, int categoryId, int createBy)
        {
            try
            {
                var toDo = _toDoRepository.GetById(toDoId);
                if(toDo != null)
                {
                    toDo.ToDoTitle = title;
                    toDo.ToDoContent = content;
                    toDo.ToDoStatus = (byte)status;
                    toDo.CategoryID = categoryId;
                    _toDoRepository.Update(toDo);
                    return ResponseBaseModel.Success("Update successfully");
                }
                return ResponseBaseModel.Failed("Not found ToDo");
            }
            catch(Exception ex)
            {
                return ResponseBaseModel.Failed(ex.Message);
            }
        }

        public bool FinishToDo(int toDoID)
        {
            try
            {
                var toDo = _toDoRepository.GetById(toDoID);
                if(toDo != null)
                {
                    if(toDo.ToDoStatus != (int)ToDoStatusValue.Done)
                    {
                        toDo.ToDoStatus = (int)ToDoStatusValue.Done;
                        _toDoRepository.Update(toDo);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<ToDoModel> GetListToDos()
        {
            var toDoList = _toDoRepository.GetAllToDos().ToList();

            return toDoList.Select(t => new ToDoModel
            {
                toDoID = t.ToDoID,
                toDoTitle = t.ToDoTitle,
                toDoContent = t.ToDoContent,
                toDoStatus = t.ToDoStatus,
                createAt = t.CreatedAt,
                updateAt = t.UpdatedAt,
                categoryID = t.CategoryID,
            });
        }
    }
}
