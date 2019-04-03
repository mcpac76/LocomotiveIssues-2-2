namespace LocomotiveIssues.Models.IssueCategory
{
    public class IssueCategoryModel
    {
        public long Id { get; set; }
        
        public long IssueCategoryNumber { get; set; }
        public string IssueCategoryName { get; set; }
        public string IssueCategoryDescription { get; set; }
    }
}