using CompetencyAssessment.Infrastructure.Abstract;
using CompetencyAssessment.Infrastructure.Repository;
using CompetencyAssessment.Models;
using ModelCompetencyAssessment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompetencyAssessment.Controllers
{
    public class UserDetailsChangePassController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserDetailViewModelChangePwd UDVMCP)
        {
            IUserDetailChangePass obj = new UserDetailsChangePasswordRepo();
            int counter=obj.UpdatePassword(UDVMCP);
            if(counter>0)
            {
                ViewData["msg"] = "Your credentials have been updated!!";
            }
            else
            {
                ViewData["msg"] = "Please check the User ID and Password you have entered!!";
            }
            return View();
        }
    }
}