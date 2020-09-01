using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagementApp.BL.Models
{
    public class UserListModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
    }
}
