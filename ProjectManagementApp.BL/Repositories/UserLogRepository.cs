using System;
using System.Collections.Generic;
using System.Linq;
using ProjectManagementApp.BL.Factories;
using ProjectManagementApp.BL.Mapper;
using ProjectManagementApp.BL.Models;

namespace ProjectManagementApp.BL.Repositories
{
    public class UserLogRepository : IUserLogRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        public UserLogRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public IEnumerable<UserLogModel> GetAll()
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return dbContext.UserLogs.Select(e => UserLogMapper.EntityToModel(e));
            }
        }

        public UserLogModel GetById(Guid id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.UserLogs.First(t => t.Id == id);
                return UserLogMapper.EntityToModel(entity);
            }
        }

        public UserLogModel Create(UserLogModel model)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = UserLogMapper.ModelToEntity(model);
                dbContext.UserLogs.Add(entity);
                dbContext.SaveChanges();
                return UserLogMapper.EntityToModel(entity);
            }
        }

        public void Update(UserLogModel model)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = UserLogMapper.ModelToEntity(model);
                dbContext.UserLogs.Update(entity);
                dbContext.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.UserLogs.First(t => t.Id == id);
                dbContext.Remove(entity);
                dbContext.SaveChanges();
            }
        }
    }
}
