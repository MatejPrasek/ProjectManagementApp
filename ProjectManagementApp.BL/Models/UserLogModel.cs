using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.EntityFrameworkCore.Migrations;
using ProjectManagementApp.DAL.Enums;

namespace ProjectManagementApp.BL.Models
{
    public class UserLogModel : BaseModel
    {
        public DateTime Timestamp { get; set; }
        public Operation Action { get; set; }
        public CommentDetailModel Comment { get; set; }
        public UserDetailModel User { get; set; }
        public TeamDetailModel Team { get; set; }
    }
}
