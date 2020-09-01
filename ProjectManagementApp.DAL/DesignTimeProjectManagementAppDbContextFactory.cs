using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProjectManagementApp.DAL
{
    class DesignTimeProjectManagementAppDbContextFactory : IDesignTimeDbContextFactory<ProjectManagementAppDbContext>
    {
        public ProjectManagementAppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProjectManagementAppDbContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ManagementApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            return new ProjectManagementAppDbContext(optionsBuilder.Options);
        }
    }
}
