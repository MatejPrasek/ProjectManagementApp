using System;
using System.Collections.Generic;
using System.Text;
using ProjectManagementApp.BL;
using ProjectManagementApp.BL.Repositories;

namespace ProjectManagementApp.BL.Tests
{
    public class ThreadRepositoryTestsFixture
    {

        private readonly IThreadRepository repository;

        public ThreadRepositoryTestsFixture()
        {
            repository = new ThreadRepository(new InMemoryDbContextFactory());
        }

        public IThreadRepository Repository => repository;

    }
}
