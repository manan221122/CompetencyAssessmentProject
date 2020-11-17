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
    public class UserCompetencyController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserCompetency UC)
        {
            int counter = 0;
            if(ModelState.IsValid)
            { 
                IUserCompetency IUC = new UserCompetencyRepository();
                counter=IUC.AddCompetency(UC);
                if(counter>0)
                {
                    ViewBag.Message = "The competency has been stored!!";
                }
                else
                {
                    ViewBag.Message = "Sorry,there is some issue with the data you are trying to save!!";
                }

            
            }
            return View();
        }

    }
}