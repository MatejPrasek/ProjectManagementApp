using System;
using System.Collections.Generic;
using System.Linq;
using ProjectManagementApp.BL.Factories;
using ProjectManagementApp.BL.Models;
using ProjectManagementApp.BL.Mapper;

namespace ProjectManagementApp.BL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        public UserRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public IEnumerable<UserListModel> GetAll()
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return dbContext.Users.Select(e => UserMapper.EntityToListModel(e));
            }
        }

        public UserDetailModel GetById(Guid id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Users.First(t => t.Id == id);
                return UserMapper.EntityToDetailModel(entity);
            }
        }

        public UserDetailModel Create(UserDetailModel model)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = UserMapper.DetailModelToEntity(model);
                dbContext.Users.Add(entity);
                dbContext.SaveChanges();
                return UserMapper.EntityToDetailModel(entity);
            }
        }

        public void Update(UserDetailModel model)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = UserMapper.DetailModelToEntity(model);
                dbContext.Users.Update(entity);
                dbContext.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Users.First(t => t.Id == id);
                dbContext.Remove(entity);
                dbContext.SaveChanges();
            }
        }
    }
}
