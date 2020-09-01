using System;
using System.Collections.Generic;
using ProjectManagementApp.BL.Models;

namespace ProjectManagementApp.BL.Repositories
{
    public interface IUserLogRepository
    {
        IEnumerable<UserLogModel> GetAll();
        UserLogModel GetById(Guid id);
        UserLogModel Create(UserLogModel model);
        void Update(UserLogModel model);
        void Delete(Guid id);
    }
}
