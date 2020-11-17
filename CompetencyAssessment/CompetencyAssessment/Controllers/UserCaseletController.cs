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
    public class UserCaseletController : Controller
    {
        IUserCaselet iucl = new UserCaseletRepo();
        [HttpGet]
        public ActionResult Index()
        {
            var ls = iucl.UserCompetency();
            ViewBag.Competency = ls;
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserCaseLet ucl)
        {
            int counter = 0;
            if(ModelState.IsValid)
            {
                counter=iucl.insertcaselet(ucl);
                if(counter>0)
                {
                    ViewBag.Message = "Your caselet has been saved!!";
                }
                else
                {
                    ViewBag.Message = "Your caselet has not been saved!!";
                }
                var ls = iucl.UserCompetency();
                ViewBag.Competency = ls;
            }
            
            return View();
        }
    }
}