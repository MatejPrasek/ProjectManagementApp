using System;
using System.Collections.Generic;
using System.Linq;
using ProjectManagementApp.BL.Factories;
using ProjectManagementApp.BL.Mapper;
using ProjectManagementApp.BL.Models;

namespace ProjectManagementApp.BL.Repositories
{
    public class ThreadRepository : IThreadRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        public ThreadRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public IEnumerable<ThreadListModel> GetAll()
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return dbContext.Threads.Select(e => ThreadMapper.EntityToListModel(e));
            }
        }

        public ThreadDetailModel GetById(Guid id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Threads.First(t => t.Id == id);
                return ThreadMapper.EntityToDetailModel(entity);
            }
        }

        public ThreadDetailModel Create(ThreadDetailModel model)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = ThreadMapper.DetailModelToEntity(model);
                dbContext.Threads.Add(entity);
                dbContext.SaveChanges();
                return ThreadMapper.EntityToDetailModel(entity);
            }
        }

        public void Update(ThreadDetailModel model)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = ThreadMapper.DetailModelToEntity(model);
                dbContext.Threads.Update(entity);
                dbContext.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Threads.First(t => t.Id == id);
                dbContext.Remove(entity);
                dbContext.SaveChanges();
            }
        }
    }
}
