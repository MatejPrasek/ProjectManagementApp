using System;
using System.Collections.Generic;
using System.Linq;
using ProjectManagementApp.BL.Factories;
using ProjectManagementApp.BL.Mapper;
using ProjectManagementApp.BL.Models;

namespace ProjectManagementApp.BL.Repositories
{
    
    public class CommentRepository : ICommentRepository
    {
        private readonly IDbContextFactory dbContextFactory;
    
        public CommentRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
    
        public IEnumerable<CommentListModel> GetAll()
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return dbContext.Comments.Select(e => CommentMapper.EntityToListModel(e));
            }
        }
    
        public CommentDetailModel GetById(Guid id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Comments.First(t => t.Id == id);
                return CommentMapper.EntityToDetailModel(entity);
            }
        }
    
        public CommentDetailModel Create(CommentDetailModel model)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = CommentMapper.DetailModelToEntity(model);
                dbContext.Comments.Add(entity);
                dbContext.SaveChanges();
                return CommentMapper.EntityToDetailModel(entity);
            }
        }
    
        public void Update(CommentDetailModel model)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = CommentMapper.DetailModelToEntity(model);
                dbContext.Comments.Update(entity);
                dbContext.SaveChanges();
            }
        }
    
        public void Delete(Guid id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Comments.First(t => t.Id == id);
                dbContext.Remove(entity);
                dbContext.SaveChanges();
            }
        }
    }
}
