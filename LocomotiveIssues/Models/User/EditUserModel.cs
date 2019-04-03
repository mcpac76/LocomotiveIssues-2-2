using System.ComponentModel;

namespace LocomotiveIssues.Models.User
{
    public class EditUserModel
    {
        public long Id { get; set; }

        [DisplayName("Firma")]
        public string CompanyName { get; set; }

        [DisplayName("Ulica")]
        public string StreetName { get; set; }
        [DisplayName("Miasto")]
        public string CityName { get; set; }
        [DisplayName("Kod pocztowy")]
        public string PostalCode { get; set; }

        [DisplayName("Numer telefonu")]
        public string PhoneNumber { get; set; }
    }
}