using MyToDoList.Models;

namespace MyToDoList.Services
{
    public interface IUserService
    {
        UserModel DoLogin(string userName, string pass);
    }
}
