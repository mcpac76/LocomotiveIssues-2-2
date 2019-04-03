using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LocomotiveIssues.Models.User
{
    public class AddUserModel
    {
        [DisplayName("Firma")]
        [Required(ErrorMessage = "Należy wpisać nazwę firmy")]
        public string CompanyName { get; set; }

        [DisplayName("Ulica")]
        [Required(ErrorMessage = "Należy wpisać nazwę ulicy i numer")]
        public string StreetName { get; set; }

        [DisplayName("Miasto")]
        [Required(ErrorMessage = "Należy wpisać nazwę miasta")]
        public string CityName { get; set; }

        [DisplayName("Kod pocztowy")]
        [Required(ErrorMessage = "Należy wpisać kod pocztowy")]
        public string PostalCode { get; set; }

        [DisplayName("Numer telefonu")]
        [Required(ErrorMessage = "Należy wpisać numer telefonu")]
        public string PhoneNumber { get; set; }

    }
}

 