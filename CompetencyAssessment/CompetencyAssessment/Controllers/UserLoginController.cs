using CompetencyAssessment.Infrastructure.Abstract;
using CompetencyAssessment.Infrastructure.Repository;
using CompetencyAssessment.Models;
using ModelCompetencyAssessment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompetencyAssessment.MyMailingService;

namespace CompetencyAssessment.Controllers
{
    public class UserLoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserDetailViewModelLogin UDVM)
        {
            IUserDetails obj = new UserDetails();
            List<UserDetail> LUD = obj.GetUserDetails(UDVM.UserID);
            string user, pass = string.Empty;
            foreach(UserDetail UD in LUD )
            {
                
                user = UD.UserID;
                pass = UD.Password;
                
            }

            if (UDVM.Password == pass)
            {
                return RedirectToAction("Index", "UserDetailHome");
            }
            else
            {
                ViewData["Error"] = "You have entered incorrect User ID or Password!!";
                
            }
            return View();
        }
        [HttpGet]
        public ActionResult GoogleLogin()
        {

            return View();
        }
        [HttpPost]
        public ActionResult GoogleLogin(AuthInput AI)
        {
            
            MailServiceClient obj = new MailServiceClient();
            AuthOutput result = obj.Validation(AI);
            if(result.ResponseStatus==200)
            {
                return RedirectToAction("Index", "UserDetailHome");
            }
            else
            {
                ViewData["Error"] = "You have entered incorrect User ID or Password!!";

            }

            return View();
        }
    }
}