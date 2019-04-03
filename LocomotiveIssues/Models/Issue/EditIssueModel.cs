using System;
using System.ComponentModel;

namespace LocomotiveIssues.Models.Issue
{
    public class EditIssueModel
    {
        public long Id { get; set; }
        
        [DisplayName("Typ")]
        public string VehicleType { get; set; }
        [DisplayName("Numer")]
        public long VehicleNumber { get; set; }
        [DisplayName("Numer boczny")]
        public string VehicleSideNumber { get; set; }
        
        [DisplayName("Firma")]
        public string CompanyName { get; set; }

        [DisplayName("Data zgłoszenia")]
        public DateTime DateOfRegistration { get; set; }
        [DisplayName("Data stwierdzenia usterki")]
        public DateTime DateOfIssue { get; set; }
        [DisplayName("Data zakończenia naprawy")]
        public DateTime DateOfEnd { get; set; }

        [DisplayName("Rodzaj usterki")]
        public string IssueCategoryName { get; set; }
        [DisplayName("Opis usterki")]
        public string IssueDescription { get; set; }

        [DisplayName("Uznanie gwarancji")]
        public bool IsGuarantee { get; set; }
        [DisplayName("Wyłączenie z eksploatacji")]
        public bool IsActive { get; set; }
    }
}

