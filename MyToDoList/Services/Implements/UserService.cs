using MyToDoList.Models;
using MyToDoList.Repositories;

namespace MyToDoList.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserModel DoLogin(string userName, string pass)
        {
            var user = _userRepository.GetByUserAndPass(userName, pass);
            if(user != null)
            {
                return new UserModel
                {
                    UserId = user.UserID,
                    UserName = user.UserName,
                };
            }
            return null;
        }
    }
    
}
