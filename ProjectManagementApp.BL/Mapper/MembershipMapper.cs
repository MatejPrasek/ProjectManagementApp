using ProjectManagementApp.BL.Models;
using ProjectManagementApp.DAL.Entities;

namespace ProjectManagementApp.BL.Mapper
{
    public class MembershipMapper
    {

        public static Membership ModelToEntity(MembershipModel model)
        {
            if (model == null) return null;
            return new Membership
            {
                Id = model.Id,
                Position = model.Position,
                User = UserMapper.DetailModelToEntity(model.User),
                Team = TeamMapper.DetailModelToEntity(model.Team)
            };
        }

        public static MembershipModel EntityToModel (Membership entity)
        {
            if (entity == null) return null;

            return new MembershipModel
            {
                Id = entity.Id,
                Position = entity.Position,
                User = UserMapper.EntityToDetailModel(entity.User),
                Team = TeamMapper.EntityToDetailModel(entity.Team)
            };
        }
    }
}
