using System;
using ProjectManagementApp.BL.Models;
using Xunit;

namespace ProjectManagementApp.BL.Tests
{
    public class TeamRepositoryTests : IClassFixture<TeamRepositoryTestsFixture>
    {
        private readonly TeamRepositoryTestsFixture fixture;

        public TeamRepositoryTests(TeamRepositoryTestsFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void Create_WithNonExistingItem_DoesNotThrow()
        {
            var user1 = new UserDetailModel
            {
                FirstName = "Jeniffer",
                Id = Guid.NewGuid(),
                LastName = "Anniston"
            };

            var user2 = new UserDetailModel
            {
                FirstName = "Ashton",
                Id = Guid.NewGuid(),
                LastName = "Kutcher"
            };

            var team = new TeamDetailModel
            {
                Id = Guid.NewGuid(),
                Name = "Film stars"
            };

            

            var model = new TeamDetailModel
            {
                Id = Guid.NewGuid(),
                Name = "Film stars",
            };

            var returnedModel = fixture.Repository.Create(model);

            Assert.NotNull(returnedModel);

            fixture.Repository.Delete(returnedModel.Id);
        }

        [Fact]
        public void GetAll_ShouldNotReturnNull()
        {
            var model = new TeamDetailModel
            {
                Id = Guid.NewGuid(),
                Name = "Film stars"
            };
            var createdModel = fixture.Repository.Create(model);

            var returnedUsersAll = fixture.Repository.GetAll();
            Assert.NotNull(returnedUsersAll);

            fixture.Repository.Delete(createdModel.Id);
        }

        [Fact]
        public void GetById_ShouldBeEqual()
        {
            var model = new TeamDetailModel
            {
                Id = Guid.NewGuid(),
                Name = "Film stars"
            };

            var createdModel = fixture.Repository.Create(model);

            Assert.Equal(createdModel.Id, fixture.Repository.GetById(createdModel.Id).Id);

            fixture.Repository.Delete(createdModel.Id);
        }

        [Fact]
        public void Update_ShouldNotEqual()
        {
            var model = new TeamDetailModel
            {
                Id = Guid.NewGuid(),
                Name = "Film stars"
            };

            var createdModel = fixture.Repository.Create(model);

            var updatedModel = model;
            updatedModel.Name = "Aloha";

            fixture.Repository.Update(updatedModel);

            var afterUpdateModel = fixture.Repository.GetById(updatedModel.Id);

            Assert.NotEqual(afterUpdateModel.Name, createdModel.Name);

            fixture.Repository.Delete(createdModel.Id);
        }

        [Fact]
        public void Delete_ShouldNotEqual()
        {
            var model = new TeamDetailModel
            {
                Id = Guid.NewGuid(),
                Name = "Film stars"
            };

            var createdModelId = fixture.Repository.Create(model).Id;

            fixture.Repository.Delete(createdModelId);
            void Act() => fixture.Repository.GetById(createdModelId);
            Assert.Throws<InvalidOperationException>((Action)Act);
        }
    }
}