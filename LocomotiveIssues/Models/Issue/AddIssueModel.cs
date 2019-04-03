using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LocomotiveIssues.Models.Issue
{
    public class AddIssueModel
    {
        [DisplayName("Numer zgłoszenia")]
        public string RegistrationNumber { get; set; }

        [DisplayName("Typ")]
        [Required(ErrorMessage = "Należy wybrać typ")]
        public string VehicleType { get; set; }
        [DisplayName("Numer")]
        public long VehicleNumber { get; set; }
        [DisplayName("Numer boczny")]
        public string VehicleSideNumber { get; set; }

        [DisplayName("Firma")]
        [Required(ErrorMessage = "Należy wybrać firmę")]
        public string CompanyName { get; set; }

        [DisplayName("Data zgłoszenia")]
        public DateTime DateOfRegistration { get; set; }
        [DisplayName("Data stwierdzenia usterki")]
        [Required(ErrorMessage = "Należy wybrać datę usterki")]
        public DateTime DateOfIssue { get; set; }
        [DisplayName("Data zakończenia naprawy")]
        public DateTime DateOfEnd { get; set; }

        [DisplayName("Rodzaj usterki")]
        [Required(ErrorMessage = "Należy wybrać typ usterki")]
        public string IssueCategoryName { get; set; }
        [DisplayName("Opis usterki")]
        [Required(ErrorMessage = "Należy opisać usterkę")]
        public string IssueDescription { get; set; }
        
        [DisplayName("Uznanie gwarancji")]
        public bool IsGuarantee { get; set; }
        [DisplayName("Wyłączenie z eksploatacji")]
        public bool IsActive { get; set; }
    }
}
