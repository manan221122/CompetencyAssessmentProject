using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ModelCompetencyAssessment
{
   public class UserRole
    {
        [Key]
        public int RoleID { get; set; }
        [Required(ErrorMessage ="Please enter the role name.")]
        [StringLength(50,ErrorMessage ="Role Name cannot be more than 50 characters")]
        public string RoleName { get; set; }
        [Required(ErrorMessage = "Please enter the Description.")]
        [StringLength(200,ErrorMessage ="Description cannot be more than 200 characters.")]
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
