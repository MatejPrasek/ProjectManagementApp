using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagementApp.BL.Mapper;
using ProjectManagementApp.BL.Models;
using ProjectManagementApp.DAL.Entities;
using ProjectManagementApp.DAL.Enums;
using Xunit;

namespace ProjectManagementApp.BL.Tests.Mapper
{
    public class UserLogMapperTests
    {
        [Fact]
        public void ModelToEntity_ShouldBeEqual()
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
                Timestamp = new DateTime(2019, 10, 22),
                Text = "Comment"
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

            var returned = UserLogMapper.ModelToEntity(model);


            Assert.Equal(model.Id, returned.Id);
            Assert.Equal(model.Action, returned.Action);
            Assert.Equal(model.Timestamp, returned.Timestamp);


            Assert.IsType<UserLog>(returned);
        }

        [Fact]
        public void EntityToModel_ShouldBeEqual()
        {
            var user = new User
            {
                FirstName = "Alfred",
                Id = Guid.NewGuid(),
                LastName = "Hitchcock"
            };

            var team = new Team
            {
                Id = Guid.NewGuid(),
                Name = "Musicians"
            };

            var comment = new Comment
            {
                Author = user,
                Id = Guid.NewGuid(),
                Timestamp = new DateTime(2019, 10, 22),
                Text = "Comment"
            };

            var model = new UserLog
            {
                Id = Guid.NewGuid(),
                Action = Operation.CommentCreate,
                Comment = comment,
                Team = team,
                Timestamp = new DateTime(2019, 4, 15),
                User = user
            };

            var returned = UserLogMapper.EntityToModel(model);


            Assert.Equal(model.Id, returned.Id);
            Assert.Equal(model.Action, returned.Action);
            Assert.Equal(model.Timestamp, returned.Timestamp);

            Assert.Equal(model.User.FirstName, returned.User.FirstName);
            Assert.Equal(model.User.LastName, returned.User.LastName);

            Assert.Equal(model.Team.Name, returned.Team.Name);

            Assert.Equal(model.Comment.Text, returned.Comment.Text);
            Assert.Equal(model.Comment.Timestamp, returned.Comment.Timestamp);

            Assert.IsType<UserLogModel>(returned);
        }
    }
}
