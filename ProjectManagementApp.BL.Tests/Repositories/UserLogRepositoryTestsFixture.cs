using System;
using System.Collections.Generic;
using System.Text;
using ProjectManagementApp.BL;
using ProjectManagementApp.BL.Repositories;

namespace ProjectManagementApp.BL.Tests
{
    public class UserLogRepositoryTestsFixture
    {

        private readonly IUserLogRepository repository;

        public UserLogRepositoryTestsFixture()
        {
            repository = new UserLogRepository(new InMemoryDbContextFactory());
        }

        public IUserLogRepository Repository => repository;

    }
}
