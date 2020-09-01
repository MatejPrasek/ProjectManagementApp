using System;
using ProjectManagementApp.BL.Models;
using ProjectManagementApp.BL.Mapper;
using ProjectManagementApp.DAL.Entities;
using Xunit;

namespace ProjectManagementApp.BL.Tests.Mapper
{
    public class UserMapperTests
    {
        [Fact]
        public void DetailModelToEntity_ShouldBeSame()
        {
            var model = new UserDetailModel
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com"
            };

            var returned = UserMapper.DetailModelToEntity(model);

            Assert.Equal(model.Id, returned.Id);
            Assert.Equal(model.FirstName, returned.FirstName);
            Assert.Equal(model.Email, returned.Email);
            Assert.Equal(model.ProfilePicture, returned.ProfilePicture);
            Assert.Equal(model.Nickname, returned.Nickname);

            Assert.IsType<User>(returned);
        }

        [Fact]
        public void EntityToDetailModel_ShouldBeSame()
        {
            var model = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com"
            };

            var returned = UserMapper.EntityToDetailModel(model);

            Assert.Equal(model.Id, returned.Id);
            Assert.Equal(model.FirstName, returned.FirstName);
            Assert.Equal(model.Email, returned.Email);
            Assert.Equal(model.ProfilePicture, returned.ProfilePicture);
            Assert.Equal(model.Nickname, returned.Nickname);

            Assert.IsType<UserDetailModel>(returned);
        }
    
        [Fact]
        public void EntityToListModel_ShouldBeSame()
        {
            var model = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com"
            };

            var returned = UserMapper.EntityToListModel(model);

            Assert.Equal(model.Id, returned.Id);
            Assert.Equal(model.FirstName, returned.FirstName);
            Assert.Equal(model.ProfilePicture, returned.ProfilePicture);

            Assert.IsType<UserListModel>(returned);
        }


        
    }
}
