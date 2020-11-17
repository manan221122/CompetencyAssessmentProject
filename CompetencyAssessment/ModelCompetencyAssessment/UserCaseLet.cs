using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelCompetencyAssessment
{
    public class UserCaseLet
    {
        [Key]
        public int CID { get; set; }
        [Required(ErrorMessage ="Please enter the caselet.")]
        [StringLength(500,ErrorMessage ="Length of  caselet cannot be more than 500 character. ")]
        public string Caselet { get; set; }
        [Required(ErrorMessage = "Please enter the solution1.")]
        [StringLength(200, ErrorMessage = "Length of  Solution1 cannot be more than 200 characters . ")]
        public string Answer1 { get; set; }
        [Required(ErrorMessage = "Please enter the solution2.")]
        [StringLength(200, ErrorMessage = "Length of  Solution2 cannot be more than 200 characters . ")]
        public string Answer2 { get; set; }
        [Required(ErrorMessage = "Please enter the solution3.")]
        [StringLength(200, ErrorMessage = "Length of  Solution3 cannot be more than 200 characters . ")]
        public string Answer3 { get; set; }
        [Required(ErrorMessage = "Please enter the solution4.")]
        [StringLength(200, ErrorMessage = "Length of  Solution4 cannot be more than 200 characters . ")]
        public string Answer4 { get; set; }
        [Required(ErrorMessage = "Please select the corresponding Competency.")]       
        public int CompID1 { get; set; }
        [Required(ErrorMessage = "Please select the corresponding Competency.")]
        public int CompID2 { get; set; }
        [Required(ErrorMessage = "Please select the corresponding Competency.")]
        public int CompID3 { get; set; }
        [Required(ErrorMessage = "Please select the corresponding Competency.")]
        public int CompID4 { get; set; }
        public bool IsActive { get; set; }
    }
}
