using System.ComponentModel;

namespace LocomotiveIssues.Models.IssueCategory
{
    public class EditIssueCategoryModel
    {
        public long Id { get; set; }
        
        [DisplayName("Numer usterki")]
        public long IssueCategoryNumber { get; set; }
        [DisplayName("Rodzaj usterki")]
        public string IssueCategoryName { get; set; }
        [DisplayName("Opis usterki")]
        public string IssueCategoryDescription { get; set; }

    }
}