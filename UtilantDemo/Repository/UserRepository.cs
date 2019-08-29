using System.Collections.Generic;
using UtilantDemo.Services.User;
using UtilantDemo.Models;

namespace UtilantDemo.Repository
{
    public class UserRepository
    {
        private IUserService _userService;

        public UserRepository(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// This method returns all users details
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserModel> FetchUsers()
        {
            var users = _userService.FetchUsers();
            return users;
        }
    }
}