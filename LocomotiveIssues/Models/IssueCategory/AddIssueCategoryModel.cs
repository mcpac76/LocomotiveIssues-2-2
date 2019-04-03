using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LocomotiveIssues.Models.IssueCategory
{
    public class AddIssueCategoryModel
    {
        [DisplayName("Numer usterki")]
        [Required(ErrorMessage = "Należy wpisać numer")]
        public long IssueCategoryNumber { get; set; }

        [DisplayName("Nazwa usterki")]
        [Required(ErrorMessage = "Należy wpisać nazwę")]
        public string IssueCategoryName { get; set; }

        [DisplayName("Opis usterki")]
        [Required(ErrorMessage = "Należy opisać usterkę")]
        public string IssueCategoryDescription { get; set; }
    }
}