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
    public class UserDetailsEditController : Controller
    {
        IUserDetails IUD = new UserDetails();
        // GET: UserDetailsEdit
        public ActionResult Index()
        {
            List<UserDetail> UD = new List<UserDetail>();
            string UID = TempData["UID"].ToString();
            UD= IUD.GetUserDetails(UID);
            return View();
        }
    }
}