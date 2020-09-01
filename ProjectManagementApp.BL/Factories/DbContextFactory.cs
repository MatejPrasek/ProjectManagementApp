using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProjectManagementApp.DAL;

namespace ProjectManagementApp.BL.Factories
{
    public class DbContextFactory : IDbContextFactory
    {
        public ProjectManagementAppDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProjectManagementAppDbContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ManagementApp;MultipleActiveResultSets = True;Integrated Security = True; ");
            return new ProjectManagementAppDbContext(optionsBuilder.Options);
        }

    }
}
