using System;
using System.Collections.Generic;
using System.Text;
using ProjectManagementApp.BL.Models;

namespace ProjectManagementApp.BL.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<UserListModel> GetAll();
        UserDetailModel GetById(Guid id);
        UserDetailModel Create(UserDetailModel model);
        void Update(UserDetailModel model);
        void Delete(Guid id);
    }
}
