using System;
using System.Collections.Generic;
using System.Linq;
using ProjectManagementApp.BL.Factories;
using ProjectManagementApp.BL.Mapper;
using ProjectManagementApp.BL.Models;

namespace ProjectManagementApp.BL.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        public TeamRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public IEnumerable<TeamListModel> GetAll()
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return dbContext.Teams.Select(e => TeamMapper.EntityToListModel(e));
            }
        }

        public TeamDetailModel GetById(Guid id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Teams.First(t => t.Id == id);
                return TeamMapper.EntityToDetailModel(entity);
            }
        }

        public TeamDetailModel Create(TeamDetailModel model)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = TeamMapper.DetailModelToEntity(model);
                dbContext.Teams.Add(entity);
                dbContext.SaveChanges();
                return TeamMapper.EntityToDetailModel(entity);
            }
        }

        public void Update(TeamDetailModel model)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = TeamMapper.DetailModelToEntity(model);
                dbContext.Teams.Update(entity);
                dbContext.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Teams.First(t => t.Id == id);
                dbContext.Remove(entity);
                dbContext.SaveChanges();
            }
        }

    }
}
