using System;
using ProjectManagementApp.BL.Mapper;
using ProjectManagementApp.BL.Models;
using ProjectManagementApp.DAL.Entities;
using ProjectManagementApp.DAL.Enums;
using Xunit;

namespace ProjectManagementApp.BL.Tests.Mapper
{
    public class MembershipMapperTests
    {
        [Fact]
        public void ModelToEntity_ShouldBeEqual()
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

            var returned = MembershipMapper.ModelToEntity(model);

            Assert.Equal(model.Id, returned.Id);
            Assert.Equal(model.Position, returned.Position);
            Assert.Equal(model.User.FirstName, returned.User.FirstName);
            Assert.Equal(model.User.LastName, returned.User.LastName);
            Assert.Equal(model.Team.Name, returned.Team.Name);

            Assert.IsType<Membership>(returned);
        }

        [Fact]
        public void EntityToModel_ShouldBeEqual()
        {
            var user = new User
            {
                FirstName = "John",
                LastName = "Doe"
            };

            var team = new Team
            {
                Id = Guid.NewGuid(),
                Name = "A team"
            };

            var model = new Membership
            {
                Id = Guid.NewGuid(),
                Position = Position.Leader,
                Team = team,
                User = user
            };

            var returned = MembershipMapper.EntityToModel(model);

            Assert.Equal(model.Id, returned.Id);
            Assert.Equal(model.Position, returned.Position);
            Assert.Equal(model.User.FirstName, returned.User.FirstName);
            Assert.Equal(model.User.LastName, returned.User.LastName);
            Assert.Equal(model.Team.Name, returned.Team.Name);

            Assert.IsType<MembershipModel>(returned);
        }
    }
}
