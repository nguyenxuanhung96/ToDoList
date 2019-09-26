using Microsoft.AspNetCore.Mvc;
using MyToDoList.Models;
using MyToDoList.Services;

namespace MyToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(
            ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("AddNew")]
        [HttpPost]
        public IActionResult AddNew([FromBody] CategoryModel model)
        {
            return Ok(_categoryService.AddNew(model.categoryName, 1));
        }
        [Route("Update")]
        [HttpPost]
        public IActionResult Update([FromBody] CategoryModel model)
        {
            return Ok(_categoryService.Update(model.categoryID, model.categoryName, 1));
        }
        [Route("Delete")]
        [HttpPost]
        public IActionResult Delete([FromBody] int categoryID)
        {
            return Ok(_categoryService.Delete(categoryID, 1));
        }

        [Route("GetListCategories")]
        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(_categoryService.GetCategories());
        }

        [Route("GetAvailable")]
        [HttpGet]
        public IActionResult GetAvailable()
        {
            return Ok(_categoryService.GetCategories());
        }
    }
}