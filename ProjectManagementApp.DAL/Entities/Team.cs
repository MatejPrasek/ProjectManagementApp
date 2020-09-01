using System;
using System.Collections.Generic;

namespace ProjectManagementApp.DAL.Entities
{
    public class Team : EntityBase
    {
        public string Name { get; set; } 
        public virtual ICollection<Membership> Members { get; set; } = new List<Membership>();
        public virtual ICollection<Thread> Threads { get; set; } = new List<Thread>();
        public virtual ICollection<UserLog> Logs { get; set; } = new List<UserLog>();

    }
}