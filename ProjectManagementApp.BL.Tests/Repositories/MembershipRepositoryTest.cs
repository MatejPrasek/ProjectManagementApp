using System;
using ProjectManagementApp.BL.Models;
using ProjectManagementApp.DAL.Enums;
using Xunit;

namespace ProjectManagementApp.BL.Tests
{
    public class MembershipRepositoryTests : IClassFixture<MembershipRepositoryTestsFixture>
    {
        private readonly MembershipRepositoryTestsFixture fixture;

        public MembershipRepositoryTests(MembershipRepositoryTestsFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void Create_WithNonExistingItem_DoesNotThrow()
        {

            var user = new UserDetailModel
            {
                FirstName = "John",
                LastName = "Doe"
            };

            var team = new TeamDetailModel
            {
                Id = Guid.NewGuid(),
                Name = "A team"
            };

            var model = new MembershipModel
            {
                Id = Guid.NewGuid(),
                Position = Position.Leader,
                Team = team,
                User = user
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
                FirstName = "John",
                LastName = "Doe"
            };

            var team = new TeamDetailModel
            {
                Id = Guid.NewGuid(),
                Name = "A team"
            };

            var model = new MembershipModel
            {
                Id = Guid.NewGuid(),
                Position = Position.Leader,
                Team = team,
                User = user
            };

            var createdModel = fixture.Repository.Create(model);

            var returnedUsersAll = fixture.Repository.GetAll();
            Assert.NotNull(returnedUsersAll);

            fixture.Repository.Delete(createdModel.Id);
        }

        [Fact]
        public void GetById_ShouldBeEqual()
        {
            var user = new UserDetailModel
            {
                FirstName = "John",
                LastName = "Doe"
            };

            var team = new TeamDetailModel
            {
                Id = Guid.NewGuid(),
                Name = "A team"
            };

            var model = new MembershipModel
            {
                Id = Guid.NewGuid(),
                Position = Position.Leader,
                Team = team,
                User = user
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
                FirstName = "John",
                LastName = "Doe"
            };

            var user2 = new UserDetailModel
            {
                FirstName = "Mike",
                LastName = "Foo"
            };

            var team = new TeamDetailModel
            {
                Id = Guid.NewGuid(),
                Name = "A team"
            };

            var createdModel = fixture.Repository.Create(new MembershipModel
            {
                Id = Guid.NewGuid(),
                Position = Position.Leader,
                Team = team,
                User = user
            });

            var updatedModel = createdModel;
            updatedModel.User = user2;

            fixture.Repository.Update(updatedModel);

            var afterUpdateModel = fixture.Repository.GetById(updatedModel.Id);

            Assert.NotEqual(afterUpdateModel.User, createdModel.User);

            fixture.Repository.Delete(createdModel.Id);
        }

        [Fact]
        public void Delete_ShouldNotEqual()
        {
            var user = new UserDetailModel
            {
                FirstName = "John",
                LastName = "Doe"
            };

            var team = new TeamDetailModel
            {
                Id = Guid.NewGuid(),
                Name = "A team"
            };

            var model = new MembershipModel
            {
                Id = Guid.NewGuid(),
                Position = Position.Leader,
                Team = team,
                User = user
            };

            var createdModelId = fixture.Repository.Create(model).Id;

            fixture.Repository.Delete(createdModelId);
            void Act() => fixture.Repository.GetById(createdModelId);
            Assert.Throws<InvalidOperationException>((Action)Act);
        }
    }
}