using CompetencyAssessment.Models;
using ModelCompetencyAssessment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CompetencyAssessment.Infrastructure.Abstract
{
    interface IUserRegisteration
    {
        int UserExistenceCheck(string UserID);
        string InsertUserData(UserDetail UD);
         List<UserRoleViewModel> UserRole();
        List<UserDetailViewModelCompetency> UserCompetency();
    }
}
