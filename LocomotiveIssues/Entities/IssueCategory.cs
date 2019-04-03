namespace LocomotiveIssues.Entities
{
    public class IssueCategory
    {
        public long Id { get; set; }

        public long IssueCategoryNumber { get; set; }
        public string IssueCategoryName { get; set; }
        public string IssueCategoryDescription { get; set; }
    }
}