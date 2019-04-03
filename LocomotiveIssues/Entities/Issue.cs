using System;


namespace LocomotiveIssues.Entities
{
    public class Issue
    {
        public long Id { get; set; }
        public long RegistrationNumber { get; set; }
        
        public Locomotive Locomotive { get; set; }

        public User User { get; set; }

        public DateTime DateOfRegistration { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfEnd { get; set; }

        public IssueCategory IssueCategory { get; set; }
        public string IssueDescription { get; set; }

        public bool IsGuarantee { get; set; }
        public bool IsActive { get; set; }
    }
}