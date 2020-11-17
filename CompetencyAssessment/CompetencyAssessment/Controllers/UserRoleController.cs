using CompetencyAssessment.Infrastructure.Abstract;
using CompetencyAssessment.Infrastructure.Repository;
using ModelCompetencyAssessment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompetencyAssessment.Controllers
{
    public class UserRoleController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserRole UR)
        {
            IUserRole iusr = new UserRoleRepository();
            int count = 0;
            count=iusr.AddUser(UR);
            if(count>0)
            {
                ViewBag.Message = "Role has been updated.";
            }
            else
            {
                ViewBag.Message = "Please check the details you have provided.";
            }
            return View();
        }
    }
}