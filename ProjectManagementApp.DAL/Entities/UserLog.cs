using System;
using ProjectManagementApp.DAL.Enums;

namespace ProjectManagementApp.DAL.Entities
{
    public class UserLog : EntityBase
    {
        public Operation Action { get; set; }
        public DateTime Timestamp { get; set; }
        public Comment Comment { get; set; }
        public User User { get; set; }
        public Team Team { get; set; }
    }
}
