using System;
using System.Collections.Generic;
using ProjectManagementApp.BL.Models;

namespace ProjectManagementApp.BL.Repositories
{
    public interface ITeamRepository
    {
        IEnumerable<TeamListModel> GetAll();
        TeamDetailModel GetById(Guid id);
        TeamDetailModel Create(TeamDetailModel model);
        void Update(TeamDetailModel model);
        void Delete(Guid id);
    }
}
