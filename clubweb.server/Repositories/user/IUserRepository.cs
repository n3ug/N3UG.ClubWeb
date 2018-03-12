using clubweb.shared.models.user;
using System;
using System.Collections.Generic;
using System.Text;

namespace clubweb.shared.interfaces
{
    public interface IUserRepository
    {
        userModel GetUserById(int id);
        IEnumerable<userModel> GetUsers(userModel criteria);
        userModel AddUser(userModel user);
        bool DeleteUser(int id);
        bool DeleteUser(userModel user);
        userModel UpdateUser(userModel user);
    }
}
