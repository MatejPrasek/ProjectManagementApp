using System;
using ProjectManagementApp.BL.Models;
using Xunit;

namespace ProjectManagementApp.BL.Tests
{
    public class ThreadRepositoryTests : IClassFixture<ThreadRepositoryTestsFixture>
    {
        private readonly ThreadRepositoryTestsFixture fixture;

        public ThreadRepositoryTests(ThreadRepositoryTestsFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void Create_WithNonExistingItem_DoesNotThrow()
        {
            var user = new UserDetailModel
            {
                FirstName = "Johny",
                Id = Guid.NewGuid(),
                LastName = "Depp"
            };

            var team = new TeamDetailModel
            {
                Id = Guid.NewGuid(),
                Name = "Pirates of the Caribean"
            };


            var model = new ThreadDetailModel
            {
                Id = Guid.NewGuid(),
                Team = team,
                Title = "Test title"
            };

            var returnedModel = fixture.Repository.Create(model);

            Assert.NotNull(returnedModel);

            fixture.Repository.Delete(returnedModel.Id);
        }

        [Fact]
        public void GetAll_ShouldNotReturnNull()
        {
            var user = new UserDetailModel
            {
                FirstName = "Johny",
                Id = Guid.NewGuid(),
                LastName = "Depp"
            };

            var team = new TeamDetailModel
            {
                Id = Guid.NewGuid(),
                Name = "Pirates of the Caribean"
            };

            var model = new ThreadDetailModel
            {
                Id = Guid.NewGuid(),
                Team = team,
                Title = "Test title"
            };
            var createdModel = fixture.Repository.Create(model);

            var returnedUsersAll = fixture.Repository.GetAll();
            Assert.NotNull(returnedUsersAll);

            fixture.Repository.Delete(createdModel.Id);
        }

        [Fact]
        public void GetById_ShouldBeEqual()
        {
            var model = new ThreadDetailModel
            {
                Id = Guid.NewGuid(),
                Title = "Test title"
            };

            var createdModel = fixture.Repository.Create(model);

            Assert.Equal(createdModel.Id, fixture.Repository.GetById(createdModel.Id).Id);

            fixture.Repository.Delete(createdModel.Id);
        }

        [Fact]
        public void Update_ShouldNotEqual()
        {
            var user = new UserDetailModel
            {
                FirstName = "Johny",
                Id = Guid.NewGuid(),
                LastName = "Depp"
            };

            var team = new TeamDetailModel
            {
                Id = Guid.NewGuid(),
                Name = "Pirates of the Caribean"
            };


            var model = new ThreadDetailModel
            {
                Id = Guid.NewGuid(),
                Team = team,
                Title = "Test title"
            };

            var createdModel = fixture.Repository.Create(model);

            var updatedModel = model;
            updatedModel.Title = "Updated title";

            fixture.Repository.Update(updatedModel);

            var afterUpdateModel = fixture.Repository.GetById(updatedModel.Id);

            Assert.NotEqual(afterUpdateModel.Title, createdModel.Title);

            fixture.Repository.Delete(createdModel.Id);
        }

        [Fact]
        public void Delete_ShouldNotEqual()
        {
            var user = new UserDetailModel
            {
                FirstName = "Johny",
                Id = Guid.NewGuid(),
                LastName = "Depp"
            };

            var team = new TeamDetailModel
            {
                Id = Guid.NewGuid(),
                Name = "Pirates of the Caribean"
            };


            var model = new ThreadDetailModel
            {
                Id = Guid.NewGuid(),
                Team = team,
                Title = "Test title"
            };

            var createdModelId = fixture.Repository.Create(model).Id;

            fixture.Repository.Delete(createdModelId);
            void Act() => fixture.Repository.GetById(createdModelId);
            Assert.Throws<InvalidOperationException>((Action)Act);
        }
    }
}