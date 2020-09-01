using System;
using System.Collections.Generic;
using ProjectManagementApp.BL.Models;

namespace ProjectManagementApp.BL.Repositories
{
    public interface IMembershipRepository
    {
        IEnumerable<MembershipModel> GetAll();
        MembershipModel GetById(Guid id);
        MembershipModel Create(MembershipModel model);
        void Update(MembershipModel model);
        void Delete(Guid id);
    }
}
