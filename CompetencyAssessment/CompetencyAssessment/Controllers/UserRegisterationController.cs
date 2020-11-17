using CompetencyAssessment.Infrastructure.Abstract;
using CompetencyAssessment.Infrastructure.Repository;
using ModelCompetencyAssessment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace CompetencyAssessment.Controllers
{
    public class UserRegisterationController : Controller
    {
        IUserRegisteration obj = new UserRegRepository();
        
        [HttpGet]
        public ActionResult Index()
        {
            //Binding the role with role drop down
            var lt=obj.UserRole();
            ViewBag.Role = lt;

            //Binding the Competency with Competency drop down
            var lc = obj.UserCompetency();
            ViewBag.Competency = lc;
            
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserDetail UD)
        {
            if (ModelState.IsValid)
            { 
                string msg, To, From, Sub, Message, status = string.Empty;

                int count=obj.UserExistenceCheck(UD.UserID);
                if(count==0)
                {
                    msg = obj.InsertUserData(UD);
                    if (msg.Contains("Success"))
                    {
                        To = UD.EmailID;
                        From = "tryemail740@gmail.com";
                        Sub = "User Registeration Status";
                        StringBuilder sb = new StringBuilder("Hi ");
                        sb.Append(UD.Name);
                        sb.Append(" ");
                        sb.Append(msg);
                        Message = sb.ToString();
                        UserDetail obj = new UserDetail();
                        // status = UserNotification.SendGeneric_Mail(To, From, Sub, Message);
                        TempData["UID"] = UD.UserID;
                        @ViewBag.status = "User has been Registered Successfully!!";
                    }
                    return RedirectToAction("Index", "UserLogin");

                }
                else
                {
                    @ViewBag.UserExistence = "User ID already Exists. Please try different User ID!!";
                }
               
            }
            return View();
        }
        
    }
}