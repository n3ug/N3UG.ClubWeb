using System;
using System.Collections.Generic;
using System.Text;

namespace clubweb.shared.models.user
{
    public class userViewModel
    {
        public userViewModel()
        {
            Id = -1;
            FirstName = "";
            LastName = "";
            FullName = "";
        }

        public userViewModel(userModel user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            FullName = $"{user.FirstName} {user.LastName}";
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
    }
}
