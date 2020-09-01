using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagementApp.BL.Models
{
    public class CommentListModel : BaseModel
    {
        public UserListModel Author { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
