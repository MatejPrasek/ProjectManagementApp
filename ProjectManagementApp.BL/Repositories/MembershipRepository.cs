using System;
using System.Collections.Generic;
using System.Linq;
using ProjectManagementApp.BL.Factories;
using ProjectManagementApp.BL.Mapper;
using ProjectManagementApp.BL.Models;

namespace ProjectManagementApp.BL.Repositories
{
    public class MembershipRepository : IMembershipRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        public MembershipRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public IEnumerable<MembershipModel> GetAll()
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return dbContext.Memberships.Select(e => MembershipMapper.EntityToModel(e));
            }
        }

        public MembershipModel GetById(Guid id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Memberships.First(t => t.Id == id);
                return MembershipMapper.EntityToModel(entity);
            }
        }

        public MembershipModel Create(MembershipModel model)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = MembershipMapper.ModelToEntity(model);
                dbContext.Memberships.Add(entity);
                dbContext.SaveChanges();
                return MembershipMapper.EntityToModel(entity);
            }
        }

        public void Update(MembershipModel model)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = MembershipMapper.ModelToEntity(model);
                dbContext.Memberships.Update(entity);
                dbContext.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Memberships.First(t => t.Id == id);
                dbContext.Remove(entity);
                dbContext.SaveChanges();
            }
        }
    }
}
