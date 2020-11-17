using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelCompetencyAssessment
{
    public class UserAssessment
    {
        [Key]
        public int AssessID { get; set; }
        [Required(ErrorMessage ="Please enter the Assessment Name.")]
        [StringLength(200,ErrorMessage =("Lenth of Assessment Name cannot be more than 200 characters"))]
        [Display(Name ="Assessment Name")]
        public string AssessName { get; set; }
        [Required(ErrorMessage = "Please select the Assessment Date.")]
        public DateTime AssessDt { get; set; }
        [Required(ErrorMessage = "Please enter the Assessment Hours.")]
        public int AssessHr { get; set; }
        [Required(ErrorMessage = "Please enter the Assessment Minutes.")]
        public int AssessMin { get; set; }
        [Required(ErrorMessage = "Please enter the Assessment Duration.")]
        public int Duration { get; set; }
    }
}
