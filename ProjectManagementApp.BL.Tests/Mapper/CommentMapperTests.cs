using System;
using ProjectManagementApp.BL.Models;
using ProjectManagementApp.BL.Mapper;
using ProjectManagementApp.DAL.Entities;
using Xunit;

namespace ProjectManagementApp.BL.Tests.Mapper
{
    public class CommentMapperTests
    {
        [Fact]
        public void EntityToDetailModel_ShouldBeEqual()
        {
            var user = new User()
            {
                FirstName = "John",
                LastName = "Doe"
            };

            var model = new Comment()
            {
                Author = user,
                Id = Guid.NewGuid(),
                Text = "This is a comment!"
            };

            var returned = CommentMapper.EntityToDetailModel(model);

            Assert.Equal(model.Author.FirstName, returned.Author.FirstName);
            Assert.Equal(model.Author.LastName, returned.Author.LastName);
            Assert.Equal(model.Id, returned.Id);
            Assert.Equal(model.Text, returned.Text);
            Assert.Equal(model.Picture, returned.Image);
            Assert.Equal(model.Timestamp, returned.Timestamp);

            Assert.IsType<CommentDetailModel>(returned);
        }

        [Fact]
        public void DetailModelToEntity_ShouldBeEqual()
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

            var returned = CommentMapper.DetailModelToEntity(model);

            Assert.Equal(model.Author.FirstName, returned.Author.FirstName);
            Assert.Equal(model.Author.LastName, returned.Author.LastName);
            Assert.Equal(model.Id, returned.Id);
            Assert.Equal(model.Text, returned.Text);
            Assert.Equal(model.Image, returned.Picture);
            Assert.Equal(model.Timestamp, returned.Timestamp);

            Assert.IsType<Comment>(returned);
        }

        [Fact]
        public void EntityToListModel_ShouldBeEqual()
        {
            var user = new User()
            {
                FirstName = "John",
                LastName = "Doe"
            };

            var model = new Comment()
            {
                Author = user,
                Id = Guid.NewGuid(),
                Text = "This is a comment!"
            };

            var returned = CommentMapper.EntityToListModel(model);

            Assert.Equal(model.Author.FirstName, returned.Author.FirstName);
            Assert.Equal(model.Author.LastName, returned.Author.LastName);
            Assert.Equal(model.Id, returned.Id);
            Assert.Equal(model.Timestamp, returned.Timestamp);

            Assert.IsType<CommentListModel>(returned);
        }
    }
}