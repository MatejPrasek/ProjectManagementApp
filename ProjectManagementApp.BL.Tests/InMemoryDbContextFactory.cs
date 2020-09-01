using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProjectManagementApp.BL.Factories;
using ProjectManagementApp.DAL;

namespace ProjectManagementApp.BL.Tests
{
    class InMemoryDbContextFactory : IDbContextFactory
    {
        public ProjectManagementAppDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProjectManagementAppDbContext>();
            optionsBuilder.UseInMemoryDatabase("TestingDB");
            return new ProjectManagementAppDbContext(optionsBuilder.Options);
        }
    }
}
