using System;
using ProjectManagementApp.BL.Mapper;
using ProjectManagementApp.BL.Models;
using ProjectManagementApp.DAL.Entities;
using Xunit;

namespace ProjectManagementApp.BL.Tests.Mapper
{
    public class ThreadMapperTests
    {
        [Fact]
        public void DetailMOdelToEntity_ShouldBeEqual()
        {
            var team = new TeamDetailModel
            {
                Id = Guid.NewGuid(),
                Name = "Pirates of the Caribean"
            };


            var model = new ThreadDetailModel
            {
                Id = Guid.NewGuid(),
                Team = team,
                Title = "Test title"
            };

            var returned = ThreadMapper.DetailModelToEntity(model);

            Assert.Equal(model.Id, returned.Id);
            Assert.Equal(model.Title, returned.Title);
            Assert.Equal(model.Team.Name, returned.Team.Name);

            Assert.IsType<Thread>(returned);
        }

        [Fact]
        public void EntityToDetailModel_ShouldBeEqual()
        {
            var team = new Team
            {
                Id = Guid.NewGuid(),
                Name = "Pirates of the Caribean"
            };


            var model = new Thread
            {
                Id = Guid.NewGuid(),
                Team = team,
                Title = "Test title"
            };

            var returned = ThreadMapper.EntityToDetailModel(model);

            Assert.Equal(model.Id, returned.Id);
            Assert.Equal(model.Title, returned.Title);
            Assert.Equal(model.Team.Name, returned.Team.Name);

            Assert.IsType<ThreadDetailModel>(returned);
        }

        [Fact]
        public void EntityToListModel_ShouldBeEqual()
        {
            var team = new Team
            {
                Id = Guid.NewGuid(),
                Name = "Pirates of the Caribean"
            };


            var model = new Thread
            {
                Id = Guid.NewGuid(),
                Team = team,
                Title = "Test title"
            };

            var returned = ThreadMapper.EntityToListModel(model);

            Assert.Equal(model.Id, returned.Id);
            Assert.Equal(model.Title, returned.Title);
            Assert.Equal(model.Team.Name, returned.Team.Name);

            Assert.IsType<ThreadListModel>(returned);
        }
    }
}
