using System;
using System.Collections.Generic;
using System.Text;
using ProjectManagementApp.BL;
using ProjectManagementApp.BL.Repositories;

namespace ProjectManagementApp.BL.Tests
{
    public class TeamRepositoryTestsFixture
    {

        private readonly ITeamRepository repository;

        public TeamRepositoryTestsFixture()
        {
            repository = new TeamRepository(new InMemoryDbContextFactory());
        }

        public ITeamRepository Repository => repository;

    }
}
