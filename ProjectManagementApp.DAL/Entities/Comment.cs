using System;
using System.Collections.Generic;

namespace ProjectManagementApp.DAL.Entities
{
    public class Comment : EntityBase
    {
        public User Author { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }
        public string Picture { get; set; }
        public Thread Thread { get; set; }
        public virtual ICollection<UserLog> Logs { get; set; } = new List<UserLog>();
    }
}