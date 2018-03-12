using clubweb.shared.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace clubweb.shared.models.user
{
    public class UserRepository : IUserRepository
    {
        List<userModel> _users;

        public UserRepository()
        {
            _users = new List<userModel>();

            // for testing
            seedData();
        }

        private void seedData()
        {
            var u = new userModel();
            u.FirstName = "Steve";
            u.LastName = "Fabian";
            u.Email = "sfabian@gooddogs.com";
            AddUser(u);
        }

        public userModel AddUser(userModel user)
        {
            int nxtId = _users.Count > 0 ? _users[_users.Count - 1].Id + 1 : 1;
            user.Id = nxtId;
            _users.Add(user);
            return user;
        }

        public bool DeleteUser(int id)
        {
            var result =_users.RemoveAll(x => x.Id == id);
            return result > 0;
        }

        public bool DeleteUser(userModel user)
        {
            return _users.Remove(user);
        }

        public userModel GetUserById(int id)
        {
            return _users.Find(x => x.Id == id);
        }

        public IEnumerable<userModel> GetUsers(userModel criteria)
        {
            return _users;
        }

        public userModel UpdateUser(userModel user)
        {
            var u = _users.FindIndex(x => x.Id == user.Id);
            if (u != -1)
            {
                _users[u] = user;
                return user;
            }

            return null;
        }
    }
}
