using ModelCompetencyAssessment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencyAssessment.Infrastructure.Abstract
{
    interface IUserCompetency
    {
        int AddCompetency(UserCompetency UC);
    }
}
