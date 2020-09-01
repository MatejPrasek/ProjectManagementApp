using System;
using System.Collections.Generic;
using System.Text;
using ProjectManagementApp.BL;
using ProjectManagementApp.BL.Repositories;

namespace ProjectManagementApp.BL.Tests
{
    public class UserRepositoryTestsFixture
    {
    
        private readonly IUserRepository repository;

        public UserRepositoryTestsFixture()
        {
            repository = new UserRepository(new InMemoryDbContextFactory());
        }

        public IUserRepository Repository => repository;

    }
}
