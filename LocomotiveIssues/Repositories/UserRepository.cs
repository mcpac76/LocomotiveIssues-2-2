using System.Collections.Generic;
using System.Linq;
using LocomotiveIssues.Entities;
using LocomotiveIssues.Models.User;

namespace LocomotiveIssues.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IssueContext db = new IssueContext();
        //private static IList<User> _users = new List<User>()
        //{
        //    new User
        //    {
        //        Id = 1,
        //        CompanyName = "EN Sp. z o.o.",
        //        StreetName = "Telefoniczna",
        //        CityName = "Elefele",
        //        PostalCode = "22-111",
        //        PhoneNumber = "222311134"
        //    },
        //    new User
        //    {
        //        Id = 2,
        //        CompanyName = "ENyny Sp. z o.o.",
        //        StreetName = "Wiejska",
        //        CityName = "Ulana",
        //        PostalCode = "43-434",
        //        PhoneNumber = "323333178"
        //    }
        //};

        private long GenerateKey()
        {
            return db.Users.Any() ? db.Users.Max(u => u.Id) + 1 : 1;
        }

        public long AddUser(AddUserModel model)
        {
            var userToAdd = new User
            {
                Id = GenerateKey(),
                CompanyName = model.CompanyName,
                StreetName = model.StreetName,
                CityName = model.CityName,
                PostalCode = model.PostalCode,
                PhoneNumber = model.PhoneNumber
                
            };
            db.Users.Add(userToAdd);
            db.SaveChanges();
            return userToAdd.Id;
        }

        public void EditUser(EditUserModel model)
        {
            var userToEdit = db.Users.SingleOrDefault(u => u.Id == model.Id);
            if(userToEdit != null)
            {
                userToEdit.CompanyName = model.CompanyName;
                userToEdit.StreetName = model.StreetName;
                userToEdit.CityName = model.CityName;
                userToEdit.PostalCode = model.PostalCode;
                userToEdit.PhoneNumber = model.PhoneNumber;
                db.SaveChanges();
                
            }
            
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            return db.Users.Select(u => new UserModel
            {
                Id = u.Id,
                CompanyName = u.CompanyName,
                StreetName = u.StreetName,
                CityName = u.CityName,
                PostalCode = u.PostalCode,
                PhoneNumber = u.PhoneNumber
            });
        }

        public EditUserModel GetUserById(long id)
        {
            return db.Users.Select(u => new EditUserModel
            {
                Id = u.Id,
                CompanyName = u.CompanyName,
                StreetName = u.StreetName,
                CityName = u.CityName,
                PostalCode = u.PostalCode,
                PhoneNumber = u.PhoneNumber
            })
            .SingleOrDefault(u => u.Id == id);
        }

        public bool Remove(long id)
        {
            var userToDelete = db.Users.SingleOrDefault(u => u.Id == id);
            if(userToDelete != null)
            {
                db.Users.Remove(userToDelete);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}