using ProjectManagementApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagementApp.DAL
{
    public class ProjectManagementAppDbContext : DbContext
    {
        public ProjectManagementAppDbContext()
        {

        }
        public ProjectManagementAppDbContext(DbContextOptions<ProjectManagementAppDbContext> contextOptions) : base(
            contextOptions)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<UserLog> UserLogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Membership> Memberships { get; set; }
    }



    
    
}
