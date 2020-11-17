using CompetencyAssessment.Infrastructure.Abstract;
using CompetencyAssessment.Infrastructure.Repository;
using CompetencyAssessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Text;
using ModelCompetencyAssessment;

namespace CompetencyAssessment.Controllers
{
    public class UserDetailForgotPasswordController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserDetailViewModelForgotPwd FP)
        {
            string pass,name = string.Empty;
            string msg = "Your passwor is ";
            List<UserDetail> LUD = new List<UserDetail>();
             IUserDetails obj1 = new UserDetails();
            LUD=obj1.GetUserDetails(FP.UserID);
            foreach (UserDetail item in LUD)
            {
                TempData["Email"] = item.EmailID;
                name = item.Name;
            }
            IUserDetailsForgotPassword obj = new UserDetailsForgotPasswordRepo();
            pass = obj.RetrievePassword(FP.UserID);
            
            if (!string.IsNullOrEmpty(pass))
            {
                string To, From, Sub, Message, status = string.Empty;
                To = (TempData["Email"]).ToString();
                From = "tryemail740@gmail.com";
                Sub = "Your Competency Assessment Password";
                StringBuilder sb = new StringBuilder("Hi ");            
                sb.Append(name);
                sb.Append(",");
                sb.Append(msg);
                sb.Append(pass);
                Message = sb.ToString();
                status = UserNotification.SendGeneric_Mail(To, From, Sub, Message);
                ViewData["msg"] = "Your password has been sent. Please check your email!!";
            }
            else
            {
                ViewData["msg"] = "Please provide correct User ID!!";
            }
            

            return View();
        }
       
    }
}