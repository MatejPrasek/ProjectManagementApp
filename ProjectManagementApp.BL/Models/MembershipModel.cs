using System;
using System.Collections.Generic;
using System.Text;
using ProjectManagementApp.DAL.Enums;

namespace ProjectManagementApp.BL.Models
{
    public class MembershipModel : BaseModel
    {
        public UserDetailModel User { get; set; }
        public TeamDetailModel Team { get; set; }
        public Position Position { get; set; }
    }
}
