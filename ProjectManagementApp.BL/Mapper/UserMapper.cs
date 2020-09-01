using ProjectManagementApp.BL.Models;
using ProjectManagementApp.DAL.Entities;

namespace ProjectManagementApp.BL.Mapper
{
    public static class UserMapper
    {
        public static User DetailModelToEntity(UserDetailModel model)
        {
            if (model == null) return null;
            return new User
            {
                Id = model.Id,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ProfilePicture = model.ProfilePicture,
                Nickname =  model.Nickname,
            };
        }

        public static UserDetailModel EntityToDetailModel(User entity)
        {
            if (entity == null) return null;
            return new UserDetailModel
            {
                Id = entity.Id,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                ProfilePicture = entity.ProfilePicture,
                Nickname = entity.Nickname,
            };
        }

        public static UserListModel EntityToListModel(User entity)
        {
            return new UserListModel
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                ProfilePicture = entity.ProfilePicture
            };
        }
    }
}
