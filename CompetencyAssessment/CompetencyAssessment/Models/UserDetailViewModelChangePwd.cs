using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompetencyAssessment.Models
{
    public class UserDetailViewModelChangePwd
    {
        public string UserID { get; set; }
        public string Password { get; set; }
        public string ChangePassword { get; set; }
        public string ConfirmChangePassword { get; set; }
    }
}