using System.Collections.Generic;
using UtilantDemo.Models;

namespace UtilantDemo.Services.User
{
    public interface IUserService
    {
        IEnumerable<UserModel> FetchUsers();
    }
}
