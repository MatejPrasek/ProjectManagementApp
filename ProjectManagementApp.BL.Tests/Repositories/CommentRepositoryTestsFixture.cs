using System;
using System.Collections.Generic;
using System.Text;
using ProjectManagementApp.BL;
using ProjectManagementApp.BL.Repositories;

namespace ProjectManagementApp.BL.Tests
{
    public class CommentRepositoryTestsFixture
    {

        private readonly ICommentRepository repository;

        public CommentRepositoryTestsFixture()
        {
            repository = new CommentRepository(new InMemoryDbContextFactory());
        }

        public ICommentRepository Repository => repository;

    }
}
