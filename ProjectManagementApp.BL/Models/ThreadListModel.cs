using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagementApp.BL.Models
{
    public class ThreadListModel : BaseModel
    {
        public string Title { get; set; }
        public TeamListModel Team { get; set; }
    }
}
