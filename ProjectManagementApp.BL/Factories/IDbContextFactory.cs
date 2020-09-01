using System;
using System.Collections.Generic;
using System.Text;
using ProjectManagementApp.DAL;

namespace ProjectManagementApp.BL.Factories
{
    public interface IDbContextFactory
    {
        ProjectManagementAppDbContext CreateDbContext();
    }
}
