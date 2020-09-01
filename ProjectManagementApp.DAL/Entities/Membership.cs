using System;
using System.Collections.Generic;
using System.Text;
using ProjectManagementApp.DAL.Enums;

namespace ProjectManagementApp.DAL.Entities
{
    public class Membership : EntityBase
    {
        public Team Team { get; set; }
        public User User { get; set; }
        public Position Position { get; set; } = Position.Member;
    }
}