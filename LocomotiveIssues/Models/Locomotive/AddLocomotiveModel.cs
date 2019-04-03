using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LocomotiveIssues.Models.Locomotive
{
    public class AddLocomotiveModel
    {
        [DisplayName("Typ")]
        [Required(ErrorMessage = "Należy wpisać typ")]
        public string VehicleType { get; set; }

        [DisplayName("Numer")]
        [Required(ErrorMessage = "Należy wpisać numer")]
        public long VehicleNumber { get; set; }

        [DisplayName("Numer boczny")]
        [Required(ErrorMessage = "Należy wpisać numer boczny")]
        public string VehicleSideNumber { get; set; }
    }
}