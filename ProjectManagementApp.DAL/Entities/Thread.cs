using System.Collections.Generic;

namespace ProjectManagementApp.DAL.Entities
{
    public class Thread : EntityBase
    {
        public string Title { get; set; }
        public Team Team { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
