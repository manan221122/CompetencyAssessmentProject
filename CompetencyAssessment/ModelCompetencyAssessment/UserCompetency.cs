using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace ModelCompetencyAssessment
{
   public class UserCompetency
    {
        [Key]
        public int CompId { get; set; }
        [Required(ErrorMessage ="Please enter your Competency Name")]        
        [StringLength(100,ErrorMessage ="Competency Name cannot be greater than 100 characters!!")]
        public string CompName { get; set; }
        [Required(ErrorMessage ="Please enter Competency Description")]
        [StringLength(250,ErrorMessage ="Competency description cannot be greater than 250 characters!!")]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
