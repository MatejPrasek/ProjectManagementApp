using System;
using ProjectManagementApp.BL.Models;
using Xunit;

namespace ProjectManagementApp.BL.Tests
{
    public class CommentRepositoryTests : IClassFixture<CommentRepositoryTestsFixture>
    {
        private readonly CommentRepositoryTestsFixture fixture;

        public CommentRepositoryTests(CommentRepositoryTestsFixture fixture)
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

            var model = new CommentDetailModel
            {
                Author = user,
                Id = Guid.NewGuid(),
                Text = "This is a comment!"
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

            var model = new CommentDetailModel
            {
                Author = user,
                Id = Guid.NewGuid(),
                Text = "This is a comment!"
            };

            var createdModel = fixture.Repository.Create(model);

            var returnedUsersAll = fixture.Repository.GetAll();
            Assert.NotNull(returnedUsersAll);

            fixture.Repository.Delete(createdModel.Id);
        }

        [Fact]
        public void GetById_ShouldBeEqual()
        {
            var createdModel = fixture.Repository.Create(new CommentDetailModel
            {
                Author = new UserDetailModel
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Id = Guid.NewGuid()
                },
                Id = Guid.NewGuid(),
                Text = "This is a comment!"
            });

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

            var user2 = user;
            user2.FirstName = "Leonardo";

            var createdModel = fixture.Repository.Create(new CommentDetailModel
            {
                Author = user,
                Id = Guid.NewGuid(),
                Text = "This is a comment!"
            });

            var updatedModel = createdModel;
            updatedModel.Author = user2;

            fixture.Repository.Update(updatedModel);

            var afterUpdateModel = fixture.Repository.GetById(updatedModel.Id);

            Assert.NotEqual(afterUpdateModel.Author, createdModel.Author);

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

            var model = new CommentDetailModel
            {
                Author = user,
                Id = Guid.NewGuid(),
                Text = "This is a comment!"
            };

            var createdModelId = fixture.Repository.Create(model).Id;

            fixture.Repository.Delete(createdModelId);
            void Act() => fixture.Repository.GetById(createdModelId);
            Assert.Throws<InvalidOperationException>((Action)Act);
        }
    }
}
