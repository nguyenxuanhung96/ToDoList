using MyToDoList.Data;
using MyToDoList.Tables;

namespace MyToDoList.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUserAndPass(string userName, string pass);
    }
}
