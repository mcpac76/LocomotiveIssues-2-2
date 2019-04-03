namespace LocomotiveIssues.Models.User
{
    public class UserModel
    {
        public long Id { get; set; }

        public string CompanyName { get; set; }
        public string StreetName { get; set; }
        public string CityName { get; set; }
        public string PostalCode { get; set; }

        public string PhoneNumber { get; set; }

    }
}