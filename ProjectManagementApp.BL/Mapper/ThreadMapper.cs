using ProjectManagementApp.BL.Models;
using ProjectManagementApp.DAL.Entities;

namespace ProjectManagementApp.BL.Mapper
{
    public class ThreadMapper
    {

        public static Thread DetailModelToEntity(ThreadDetailModel model)
        {
            if (model == null) return null;
            return new Thread
            {
                Id = model.Id,
                Title = model.Title,
                Team = TeamMapper.DetailModelToEntity(model.Team)
            };
        }

        public static ThreadDetailModel EntityToDetailModel(Thread entity)
        {
            if (entity == null) return null;
            return new ThreadDetailModel
            {
                Id = entity.Id,
                Title = entity.Title,
                Team = TeamMapper.EntityToDetailModel(entity.Team)
            };
        }

        public static ThreadListModel EntityToListModel(Thread entity)
        {
            return new ThreadListModel
            {
                Id = entity.Id,
                Title = entity.Title,
                Team = TeamMapper.EntityToListModel(entity.Team)
            };
        }
    }
}
