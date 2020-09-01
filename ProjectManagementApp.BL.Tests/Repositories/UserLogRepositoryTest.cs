using System;
using ProjectManagementApp.BL.Models;
using ProjectManagementApp.DAL.Enums;
using Xunit;

namespace ProjectManagementApp.BL.Tests
{
    public class UserLogRepositoryTests : IClassFixture<UserLogRepositoryTestsFixture>
    {
        private readonly UserLogRepositoryTestsFixture fixture;

        public UserLogRepositoryTests(UserLogRepositoryTestsFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void Create_WithNonExistingItem_DoesNotThrow()
        {
            var user = new UserDetailModel
            {
                FirstName = "Alfred",
                Id = Guid.NewGuid(),
                LastName = "Hitchcock"
            };

            var team = new TeamDetailModel
            {
                Id = Guid.NewGuid(),
                Name = "Musicians"
            };

            var comment = new CommentDetailModel
            {
                Author = user,
                Id = Guid.NewGuid(),
                Timestamp = new DateTime(2019, 10, 22)
            };

            var model = new UserLogModel
            {
                Id = Guid.NewGuid(),
                Action = Operation.CommentCreate,
                Comment = comment,
                Team = team,
                Timestamp = new DateTime(2019, 4, 15),
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
                FirstName = "Alfred",
                Id = Guid.NewGuid(),
                LastName = "Hitchcock"
            };

            var team = new TeamDetailModel
            {
                Id = Guid.NewGuid(),
                Name = "Musicians"
            };

            var comment = new CommentDetailModel
            {
                Author = user,
                Id = Guid.NewGuid(),
                Timestamp = new DateTime(2019, 10, 22)
            };

            var model = new UserLogModel
            {
                Id = Guid.NewGuid(),
                Action = Operation.CommentCreate,
                Comment = comment,
                Team = team,
                Timestamp = new DateTime(2019, 4, 15),
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
                FirstName = "Alfred",
                Id = Guid.NewGuid(),
                LastName = "Hitchcock"
            };

            var team = new TeamDetailModel
            {
                Id = Guid.NewGuid(),
                Name = "Musicians"
            };

            var comment = new CommentDetailModel
            {
                Author = user,
                Id = Guid.NewGuid(),
                Timestamp = new DateTime(2019, 10, 22)
            };

            var createdModel = fixture.Repository.Create(new UserLogModel
            {
                Id = Guid.NewGuid(),
                Action = Operation.CommentCreate,
            });

            Assert.Equal(createdModel.Id, fixture.Repository.GetById(createdModel.Id).Id);

            fixture.Repository.Delete(createdModel.Id);
        }

        [Fact]
        public void Update_ShouldNotEqual()
        {
            var user = new UserDetailModel
            {
                FirstName = "Alfred",
                Id = Guid.NewGuid(),
                LastName = "Hitchcock"
            };

            var team = new TeamDetailModel
            {
                Id = Guid.NewGuid(),
                Name = "Musicians"
            };

            var comment = new CommentDetailModel
            {
                Author = user,
                Id = Guid.NewGuid(),
                Timestamp = new DateTime(2019, 10, 22)
            };

            var model = new UserLogModel
            {
                Id = Guid.NewGuid(),
                Action = Operation.CommentCreate,
                Comment = comment,
                Team = team,
                Timestamp = new DateTime(2019, 4, 15),
                User = user
            };

            var oldTimestamp = model.Timestamp;

            var createdModel = fixture.Repository.Create(model);

            model.Timestamp = new DateTime(1998, 3, 19);

            fixture.Repository.Update(model);

            var newTimestamp = fixture.Repository.GetById(model.Id).Timestamp;

            Assert.NotEqual(oldTimestamp, newTimestamp);

            fixture.Repository.Delete(createdModel.Id);
        }

        [Fact]
        public void Delete_ShouldNotEqual()
        {
            var user = new UserDetailModel
            {
                FirstName = "Alfred",
                Id = Guid.NewGuid(),
                LastName = "Hitchcock"
            };

            var team = new TeamDetailModel
            {
                Id = Guid.NewGuid(),
                Name = "Musicians"
            };

            var comment = new CommentDetailModel
            {
                Author = user,
                Id = Guid.NewGuid(),
                Timestamp = new DateTime(2019, 10, 22)
            };

            var model = new UserLogModel
            {
                Id = Guid.NewGuid(),
                Action = Operation.CommentCreate,
                Comment = comment,
                Team = team,
                Timestamp = new DateTime(2019, 4, 15),
                User = user
            };

            var createdModelId = fixture.Repository.Create(model).Id;

            fixture.Repository.Delete(createdModelId);
            void Act() => fixture.Repository.GetById(createdModelId);
            Assert.Throws<InvalidOperationException>((Action)Act);
        }
    }
}