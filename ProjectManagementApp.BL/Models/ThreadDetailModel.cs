using System.Collections.Generic;
using ProjectManagementApp.DAL.Entities;

namespace ProjectManagementApp.BL.Models
{
    public class ThreadDetailModel : BaseModel
    {
        public string Title { get; set; }
        public TeamDetailModel Team { get; set; }
    }
}