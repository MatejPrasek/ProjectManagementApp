using ProjectManagementApp.BL.Models;
using ProjectManagementApp.DAL.Entities;

namespace ProjectManagementApp.BL.Mapper
{
    public class UserLogMapper
    {
        public static UserLogModel EntityToModel(UserLog entity)
        {
            if (entity == null) return null;

            return new UserLogModel
            {
                Id = entity.Id,
                Action = entity.Action,
                Timestamp = entity.Timestamp,
                User = UserMapper.EntityToDetailModel(entity.User),
                Comment = CommentMapper.EntityToDetailModel(entity.Comment),
                Team = TeamMapper.EntityToDetailModel(entity.Team)
            };
        }

        public static UserLog ModelToEntity(UserLogModel model)
        {
            if (model == null) return null;

            return new UserLog
            {
                Id = model.Id,
                Action = model.Action,
                Timestamp = model.Timestamp,
            };
        }
    }
}
