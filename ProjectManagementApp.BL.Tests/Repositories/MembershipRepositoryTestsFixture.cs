using System;
using System.Collections.Generic;
using System.Text;
using ProjectManagementApp.BL;
using ProjectManagementApp.BL.Repositories;

namespace ProjectManagementApp.BL.Tests
{
    public class MembershipRepositoryTestsFixture
    {

        private readonly IMembershipRepository repository;

        public MembershipRepositoryTestsFixture()
        {
            repository = new MembershipRepository(new InMemoryDbContextFactory());
        }

        public IMembershipRepository Repository => repository;

    }
}
