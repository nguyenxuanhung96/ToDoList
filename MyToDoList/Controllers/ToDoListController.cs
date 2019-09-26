using Microsoft.AspNetCore.Mvc;
using MyToDoList.Models;
using MyToDoList.Services;
using MyToDoList.Utilities;

namespace MyToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoService _toDoService;
        public ToDoListController(
            IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [Route("GetListToDos")]
        [HttpGet]
        public IActionResult GetListToDos()
        {
            return Ok(_toDoService.GetListToDos());
        }

        [Route("AddToDo")]
        [HttpPost]
        public IActionResult AddNew([FromBody] ToDoModel model)
        {
            return Ok(_toDoService.AddToDo(model.toDoTitle, model.toDoContent, model.toDoStatus, model.categoryID, 1));
        }

        [Route("FinishToDo")]
        [HttpPost]
        public IActionResult Finish([FromBody] int toDoID)
        {
            return Ok(_toDoService.FinishToDo(toDoID));
        }

        [Route("EditToDo")]
        [HttpPost]
        public IActionResult Edit([FromBody] ToDoModel model)
        {
            return Ok(_toDoService.EditToDo(model.toDoID, model.toDoTitle, model.toDoContent, model.toDoStatus, model.categoryID, 1));
        }

        [Route("GetToDoStatusValue")]
        [HttpGet]
        public IActionResult GetToDoStatusValue()
        {
            return Ok(EnumHelper.GetToDoStatusValues());
        }
    }
}