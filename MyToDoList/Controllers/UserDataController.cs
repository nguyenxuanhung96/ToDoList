using Microsoft.AspNetCore.Mvc;
using MyToDoList.ApiModels;
using MyToDoList.Models;
using MyToDoList.Repositories;
using MyToDoList.Services;
using MyToDoList.Tables;
using System.Collections.Generic;
using System.Linq;

namespace MyToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserDataController(
            IUserService userService
            )
        {
            _userService = userService;
        }

        [Route("Login")]
        [HttpPost]
        public UserModel DoLogin([FromBody] InputUserModel model)
        {
            return _userService.DoLogin(model.userName, model.pass);
        }
    }
}