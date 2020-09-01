using System;
using System.Collections.Generic;
using ProjectManagementApp.BL.Models;

namespace ProjectManagementApp.BL.Repositories
{
    public interface IThreadRepository
    {
        IEnumerable<ThreadListModel> GetAll();
        ThreadDetailModel GetById(Guid id);
        ThreadDetailModel Create(ThreadDetailModel model);
        void Update(ThreadDetailModel model);
        void Delete(Guid id);
    }
}
