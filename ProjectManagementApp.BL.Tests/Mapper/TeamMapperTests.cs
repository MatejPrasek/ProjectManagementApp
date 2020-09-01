using System;
using ProjectManagementApp.BL.Mapper;
using ProjectManagementApp.BL.Models;
using ProjectManagementApp.DAL.Entities;
using Xunit;

namespace ProjectManagementApp.BL.Tests.Mapper
{
    public class TeamMapperTests
    {
        [Fact]
        public void DetailModelToEntity_ShouldBeEqual()
        {
            var model = new TeamDetailModel
            {
                Id = Guid.NewGuid(),
                Name = "Film stars",
            };

            var returned = TeamMapper.DetailModelToEntity(model);

            Assert.Equal(model.Id, returned.Id);
            Assert.Equal(model.Name, returned.Name);

            Assert.IsType<Team>(returned);
        }

        [Fact]
        public void EntityToDetailModel_ShouldBeEqual()
        {
            var model = new Team()
            {
                Id = Guid.NewGuid(),
                Name = "Film stars",
            };

            var returned = TeamMapper.EntityToDetailModel(model);

            Assert.Equal(model.Id, returned.Id);
            Assert.Equal(model.Name, returned.Name);

            Assert.IsType<TeamDetailModel>(returned);
        }

        [Fact]
        public void EntityToListModel_ShouldBeEqual()
        {
            var model = new Team()
            {
                Id = Guid.NewGuid(),
                Name = "Film stars",
            };

            var returned = TeamMapper.EntityToListModel(model);

            Assert.Equal(model.Id, returned.Id);
            Assert.Equal(model.Name, returned.Name);

            Assert.IsType<TeamListModel>(returned);
        }
    }
}
