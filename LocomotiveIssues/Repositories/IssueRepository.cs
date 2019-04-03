using System;
using System.Collections.Generic;
using System.Linq;
using LocomotiveIssues.Entities;
using LocomotiveIssues.Models.Issue;

namespace LocomotiveIssues.Repositories
{
    public class IssueRepository : IIssueRepository
    {
        private readonly IssueContext db = new IssueContext();

        //public static IList<Issue> _issues = new List<Issue>()
        //{
        //    new Issue
        //    {
        //        Id = 1,
        //        RegistrationNumber = 000001,
        //        Locomotive = new Locomotive
        //        {
        //            Id = 1,
        //            VehicleType = "EN007",
        //            VehicleNumber = 200,
        //            VehicleSideNumber = "EN007-200"
        //        },
                
        //        User = new User
        //        {
        //            Id = 1,
        //            CompanyName = "EN Sp. z o.o.",
        //            StreetName = "Telefoniczna",
        //            CityName = "Elefele",
        //            PostalCode = "22-111",
        //            PhoneNumber = "222311134"
        //        },
        //        DateOfRegistration = DateTime.Now,
        //        DateOfIssue = DateTime.Now,
        //        DateOfEnd = DateTime.Now,
        //        IssueCategory = new IssueCategory
        //        {
        //            Id = 1,
        //            IssueCategoryNumber = 20,
        //            IssueCategoryName = "Podwozie",
        //            IssueCategoryDescription = "efewef fewfwef fewfewfew fewfewf"
        //        },
                
        //        IssueDescription = "wpisujemy opis problemu",
        //        IsGuarantee = true,
        //        IsActive = true,


        //    },
        //    new Issue
        //    {
        //        Id = 2,
        //        RegistrationNumber = 000002,
        //        Locomotive = new Locomotive
        //        {
        //            Id = 2,
        //            VehicleType = "ST44",
        //            VehicleNumber = 010,
        //            VehicleSideNumber = "ST44-010"
        //        },
        //        User = new User
        //        {
        //            Id = 2,
        //            CompanyName = "ENyny Sp. z o.o.",
        //            StreetName = "Wiejska",
        //            CityName = "Ulana",
        //            PostalCode = "43-434",
        //            PhoneNumber = "323333178"
        //        },
        //        DateOfRegistration = DateTime.Now,
        //        DateOfIssue = DateTime.Now,
        //        DateOfEnd = DateTime.Now,
        //        IssueCategory = new IssueCategory
        //        {
        //            Id = 2,
        //            IssueCategoryNumber = 25,
        //            IssueCategoryName = "Elektronika",
        //            IssueCategoryDescription = "dwqwq wqdqwdw efewef fewfwef fewfewfew fewfewf"
        //        },
        //        IssueDescription = "kolejny opis usterki",
        //        IsGuarantee = false,
        //        IsActive = true,

        //    }
        // };

        //    public LocomotiveRepository()
        //{
        //    if (locomotive == null)
        //    {
        //        GetAllLocomotive();
        //    }

        //}

        public long AddIssue(AddIssueModel model)
        {
            var issueToAdd = new Issue
            {
                Id = GenerateKey(),
                RegistrationNumber = GenerateRNKey(),
                Locomotive = new Locomotive
                {
                
                    VehicleType = model.VehicleType,
                    VehicleNumber = model.VehicleNumber,
                    VehicleSideNumber = model.VehicleSideNumber
                },

                User = new User
                {
                    CompanyName = model.CompanyName,
                    
                },
                DateOfRegistration = model.DateOfRegistration,
                DateOfIssue = model.DateOfIssue,
                DateOfEnd = model.DateOfEnd,
                IssueCategory = new IssueCategory
                {
                    IssueCategoryName = model.IssueCategoryName
                },
                IssueDescription = model.IssueDescription,
                IsGuarantee = model.IsGuarantee,
                IsActive = model.IsActive

            };
            db.Issues.Add(issueToAdd);
            db.SaveChanges();
            return issueToAdd.Id;
            
        }

        

        public void EditIssue(EditIssueModel model)
        {
            var issueToEdit = db.Issues.SingleOrDefault(i => i.Id == model.Id);
            if(issueToEdit != null)
            {

                issueToEdit.Locomotive.VehicleType = model.VehicleType;
                issueToEdit.Locomotive.VehicleNumber = model.VehicleNumber;
                issueToEdit.Locomotive.VehicleSideNumber = model.VehicleSideNumber;
                issueToEdit.User.CompanyName = model.CompanyName;
                issueToEdit.DateOfRegistration = model.DateOfRegistration;
                issueToEdit.DateOfIssue = model.DateOfIssue;
                issueToEdit.DateOfEnd = model.DateOfEnd;
                issueToEdit.IssueCategory.IssueCategoryName = model.IssueCategoryName;
                issueToEdit.IssueDescription = model.IssueDescription;
                issueToEdit.IsGuarantee = model.IsGuarantee;
                issueToEdit.IsActive = model.IsActive;
                db.SaveChanges();
            }
        }

        public IEnumerable<IssueModel> GetAllIssues()
        {
            return db.Issues.Select(i => new IssueModel
            {
                Id = i.Id,
                RegistrationNumber = i.RegistrationNumber,
                VehicleType = i.Locomotive.VehicleType,
                VehicleNumber = i.Locomotive.VehicleNumber,
                VehicleSideNumber = i.Locomotive.VehicleSideNumber,
                CompanyName = i.User.CompanyName,
                DateOfRegistration = i.DateOfRegistration,
                DateOfIssue = i.DateOfIssue,
                DateOfEnd = i.DateOfEnd,
                IssueCategoryName = i.IssueCategory.IssueCategoryName,
                IssueDescription = i.IssueDescription,
                IsGuarantee = i.IsGuarantee,
                IsActive = i.IsActive
            });
        }

        public EditIssueModel GetIssueById(long id)
        {
            return db.Issues.Select(i => new EditIssueModel
            {
                Id = i.Id,
                VehicleType = i.Locomotive.VehicleType,
                VehicleNumber = i.Locomotive.VehicleNumber,
                VehicleSideNumber = i.Locomotive.VehicleSideNumber,
                CompanyName = i.User.CompanyName,
                DateOfRegistration = i.DateOfRegistration,
                DateOfIssue = i.DateOfIssue,
                DateOfEnd = i.DateOfEnd,
                IssueCategoryName = i.IssueCategory.IssueCategoryName,
                IssueDescription = i.IssueDescription,
                IsGuarantee = i.IsGuarantee,
                IsActive = i.IsActive
            })
            .SingleOrDefault(i => i.Id == id);
        }

        private long GenerateKey()
        {
            return db.Issues.Any() ? db.Issues.Max(i => i.Id) + 1 : 1;
        }  

        private long GenerateRNKey()
        {

            return db.Issues.Any() ? db.Issues.Max(i => i.RegistrationNumber) + 1 : 1;
        }
     }
}