using MyToDoList.Contexts;
using MyToDoList.Data;
using MyToDoList.Tables;
using System.Linq;

namespace MyToDoList.Repositories.Implements
{
    public class UserRepository : BaseRepositoryService<ToDoListDataContext, User>, IUserRepository
    {
        public UserRepository(IDaoFactory daoFactory) : base(daoFactory.GetDataContext())
        {
        }

        public User GetByUserAndPass(string userName, string pass)
        {
            return GetAll().FirstOrDefault(u => u.UserName == userName && u.UserPassword == pass);
        }
    }
}
