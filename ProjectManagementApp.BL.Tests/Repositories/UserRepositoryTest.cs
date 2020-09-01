using System;
using ProjectManagementApp.BL.Models;
using Xunit;

namespace ProjectManagementApp.BL.Tests
{
    public class UserRepositoryTests : IClassFixture<UserRepositoryTestsFixture>
    {
        private readonly UserRepositoryTestsFixture fixture;

        public UserRepositoryTests(UserRepositoryTestsFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void Create_WithNonExistingItem_DoesNotThrow()
        {
            var model = new UserDetailModel
            {
                FirstName = "Almost",
                LastName = "Working",
                Email = "AlmostWorking@email.com"
            };

            var returnedModel = fixture.Repository.Create(model);

            Assert.NotNull(returnedModel);

            fixture.Repository.Delete(returnedModel.Id);
        }

        [Fact]
        public void GetAll_ShouldNotReturnNull()
        {
            var model = new UserDetailModel
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com"
            };
            var createdModel = fixture.Repository.Create(model);

            var returnedUsersAll = fixture.Repository.GetAll();
            Assert.NotNull(returnedUsersAll);

            fixture.Repository.Delete(createdModel.Id);
        }

        [Fact]
        public void GetById_ShouldBeEqual()
        {
            var createdModel = fixture.Repository.Create(new UserDetailModel
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com"
            });

            Assert.Equal(createdModel.Id, fixture.Repository.GetById(createdModel.Id).Id);

            fixture.Repository.Delete(createdModel.Id);
        }

        [Fact]
        public void Update_ShouldNotEqual()
        {
            var createdModel = fixture.Repository.Create(new UserDetailModel
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com"
            });

            var updatedModel = fixture.Repository.GetById(createdModel.Id);
            updatedModel.FirstName = "Leonardo";

            fixture.Repository.Update(updatedModel);

            var afterUpdateModel = fixture.Repository.GetById(updatedModel.Id);

            Assert.NotEqual(afterUpdateModel.FirstName, createdModel.FirstName);

            fixture.Repository.Delete(createdModel.Id);
        }

        [Fact]
        public void Delete_ShouldNotEqual()
        {
            var model = new UserDetailModel
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com"
            };

            var createdModelId = fixture.Repository.Create(model).Id;

            fixture.Repository.Delete(createdModelId);
            void Act() => fixture.Repository.GetById(createdModelId);
            Assert.Throws<InvalidOperationException>((Action) Act);
        }
    }
}
