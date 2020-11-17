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
    public class UserAssessmentController : Controller
    {
        IUserAssessment IUA = new UserAssessmentRepo();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserAssessment UA)
        {
            int counter = 0;
            counter=IUA.insertAssessment(UA);
            if(counter>0)
            {
                ViewBag.Message = "Your data has been stored!!";
            }
            else
            {
                ViewBag.Message = "Your data has not been stored!!";
            }
            return View();
        }
    }
}