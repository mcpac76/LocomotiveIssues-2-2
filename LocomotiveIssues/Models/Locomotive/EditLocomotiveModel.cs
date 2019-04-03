using System.ComponentModel;

namespace LocomotiveIssues.Models.Locomotive
{
    public class EditLocomotiveModel
    {
        public long Id { get; set; }

        [DisplayName("Typ")]
        public string VehicleType { get; set; }
        [DisplayName("Numer")]
        public long VehicleNumber { get; set; }
        [DisplayName("Numer boczny")]
        public string VehicleSideNumber { get; set; }
    }
}