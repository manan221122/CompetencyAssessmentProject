using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;


namespace ModelCompetencyAssessment
{
    public class UserDetail
    {
        #region Public Properties
        public int ID { get; set; }
        [Required]
        [StringLength(15,MinimumLength =6,ErrorMessage ="User ID should be greater than 6 characters and less than 15 characters.")]
        public string UserID { get; set; }
        public string EmployeeID { get; set; }
        [Required(ErrorMessage ="Email Id cannot be blank.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string EmailID { get; set; }
        [Required(ErrorMessage = "Email Id cannot be blank.")]
        [StringLength(25,MinimumLength =3,ErrorMessage ="Name should be more than 3 characters and less than 25 characters.")]
        public string Name { get; set; }
        
        public DateTime DOB { get; set; }
        
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter your password.")]
        public string Password { get; set; }
        public DateTime LastLoggedOnDate { get; set; }
        [Required(ErrorMessage = "Please select the competency.")]
        public int CompId { get; set; }
        [Required(ErrorMessage = "Please select the role.")]
        public int RoleID { get; set; }
        #endregion



    }
}
