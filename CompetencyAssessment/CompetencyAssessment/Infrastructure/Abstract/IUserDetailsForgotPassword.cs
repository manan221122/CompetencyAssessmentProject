using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompetencyAssessment.Infrastructure.Abstract
{
    interface IUserDetailsForgotPassword
    {
        string RetrievePassword(string UID);

    }
}