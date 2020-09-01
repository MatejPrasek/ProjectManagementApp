using System;
using System.Collections.Generic;
using System.Text;
using ProjectManagementApp.DAL.Entities;

namespace ProjectManagementApp.BL.Models
{
    public class UserDetailModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ProfilePicture { get; set; }
        public string Nickname { get; set; }
    }
}
