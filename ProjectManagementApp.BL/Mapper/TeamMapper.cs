using ProjectManagementApp.BL.Models;
using ProjectManagementApp.DAL.Entities;

namespace ProjectManagementApp.BL.Mapper
{
    public class TeamMapper
    {
        public static Team DetailModelToEntity(TeamDetailModel model)
        {
            if (model == null) return null;

            return new Team
            {
                Id = model.Id,
                Name = model.Name,
            };
        }

        public static TeamDetailModel EntityToDetailModel(Team entity)
        {
            if (entity == null) return null;

            return new TeamDetailModel
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }

        public static TeamListModel EntityToListModel(Team entity)
        {
            return new TeamListModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
