using System;

namespace LocomotiveIssues.Models.Issue
{
    public class IssueModel
    {
        public long Id { get; set; }
        public long RegistrationNumber { get; set; }


        public string VehicleType { get; set; }
        public long VehicleNumber { get; set; }
        public string VehicleSideNumber { get; set; }

        public string CompanyName { get; set; }

        public DateTime DateOfRegistration { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfEnd { get; set; }

        public string IssueCategoryName { get; set; }
        public string IssueDescription { get; set; }

        public bool IsGuarantee { get; set; }
        public bool IsActive { get; set; }
    }
}