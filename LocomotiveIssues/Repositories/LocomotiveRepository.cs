using System.Collections.Generic;
using System.Linq;
using LocomotiveIssues.Entities;
using LocomotiveIssues.Models.Locomotive;

namespace LocomotiveIssues.Repositories
{
    public class LocomotiveRepository : ILocomotiveRepository
    {
        private readonly IssueContext db = new IssueContext();
        //private static IList<Locomotive> _locomotives = new List<Locomotive>()
        //{
        //    new Locomotive
        //    {
        //        Id = 1,
        //        VehicleType = "EN007",
        //        VehicleNumber = 200,
        //        VehicleSideNumber = "EN007-200"


        //    },
        //    new Locomotive
        //    {
        //        Id = 2,
        //        VehicleType = "ST44",
        //        VehicleNumber = 010,
        //        VehicleSideNumber = "ST44-010"
        //    }
        // };

        private long GenerateKey()
        {
            return db.Locomotives.Any() ? db.Locomotives.Max(u => u.Id) + 1 : 1;
        }

        public long AddLocomotive(AddLocomotiveModel model)
        {
            var locomotiveToAdd = new Locomotive
            {
                Id = GenerateKey(),
                VehicleType = model.VehicleType,
                VehicleNumber = model.VehicleNumber,
                VehicleSideNumber = model.VehicleSideNumber

            };
            db.Locomotives.Add(locomotiveToAdd);
            db.SaveChanges();
            return locomotiveToAdd.Id;
        }

       

        public void EditLocomotive(EditLocomotiveModel model)
        {
            var locomotiveToEdit = db.Locomotives.SingleOrDefault(l => l.Id == model.Id);
            if(locomotiveToEdit != null)
            {
                locomotiveToEdit.VehicleType = model.VehicleType;
                locomotiveToEdit.VehicleNumber = model.VehicleNumber;
                locomotiveToEdit.VehicleSideNumber = model.VehicleSideNumber;
                db.SaveChanges();
            }
        }

        public bool Remove(long id)
        {
            var locomotiveToDelete = db.Locomotives.SingleOrDefault(l => l.Id == id);
            if(locomotiveToDelete != null)
            {
                db.Locomotives.Remove(locomotiveToDelete);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<LocomotiveModel> GetAllLocomotives()
        {
            return db.Locomotives.Select(l => new LocomotiveModel
            {
                Id = l.Id,
                VehicleType = l.VehicleType,
                VehicleNumber = l.VehicleNumber,
                VehicleSideNumber = l.VehicleSideNumber

            });
        }

        public EditLocomotiveModel GetLocomotiveById(long id)
        {
            return db.Locomotives.Select(l => new EditLocomotiveModel
            {
                Id = l.Id,
                VehicleType = l.VehicleType,
                VehicleNumber = l.VehicleNumber,
                VehicleSideNumber = l.VehicleSideNumber
            })
            .SingleOrDefault(l => l.Id == id);
        }
    }
}