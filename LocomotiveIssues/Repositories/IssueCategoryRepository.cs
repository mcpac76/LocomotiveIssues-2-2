using System.Collections.Generic;
using System.Linq;
using LocomotiveIssues.Entities;
using LocomotiveIssues.Models.IssueCategory;

namespace LocomotiveIssues.Repositories
{
    public class IssueCategoryRepository : IIssueCategoryRepository
    {
        private readonly IssueContext db = new IssueContext();
        //private static IList<IssueCategory> _issuescategories = new List<IssueCategory>()
        //{
        //    new IssueCategory
        //    {
        //        Id = 1,

        //        IssueCategoryNumber = 20,
        //        IssueCategoryName = "Podwozie",
        //        IssueCategoryDescription = "efewef fewfwef fewfewfew fewfewf"
        //    },
        //    new IssueCategory
        //    {
        //        Id = 2,

        //        IssueCategoryNumber = 25,
        //        IssueCategoryName = "Elektronika",
        //        IssueCategoryDescription = "dwqwq wqdqwdw efewef fewfwef fewfewfew fewfewf"
        //    }
        //};



        private long GenerateKey()
        {
            return db.IssuesCategories.Any() ? db.IssuesCategories.Max(u => u.Id) + 1 : 1;
        }
            
        public long AddIssueCategory(AddIssueCategoryModel model)
        {
            var issuecategoryToAdd = new IssueCategory
            {
                Id = GenerateKey(),
                IssueCategoryNumber = model.IssueCategoryNumber,
                IssueCategoryName = model.IssueCategoryName,
                IssueCategoryDescription = model.IssueCategoryDescription
            };
            db.IssuesCategories.Add(issuecategoryToAdd);
            db.SaveChanges();
            return issuecategoryToAdd.Id;
        }

        public void EditIssueCategory(EditIssueCategoryModel model)
        {
            var issuecategoryToEdit = db.IssuesCategories.SingleOrDefault(l => l.Id == model.Id);
            if (issuecategoryToEdit != null)
            {
                issuecategoryToEdit.IssueCategoryNumber = model.IssueCategoryNumber;
                issuecategoryToEdit.IssueCategoryName = model.IssueCategoryName;
                issuecategoryToEdit.IssueCategoryDescription = model.IssueCategoryDescription;
                db.SaveChanges();
            }
        }

        public IEnumerable<IssueCategoryModel> GetAllIssuesCategories()
        {
            return db.IssuesCategories.Select(l => new IssueCategoryModel 
            {
                Id = l.Id,
                IssueCategoryNumber = l.IssueCategoryNumber,
                IssueCategoryName = l.IssueCategoryName,
                IssueCategoryDescription = l.IssueCategoryDescription
            });
        }

        public EditIssueCategoryModel GetIssueCategoryById(long id)
        {
            return db.IssuesCategories.Select(l => new EditIssueCategoryModel
            {
                Id = l.Id,
                IssueCategoryNumber = l.IssueCategoryNumber,
                IssueCategoryName = l.IssueCategoryName,
                IssueCategoryDescription = l.IssueCategoryDescription
            })
            .SingleOrDefault(l => l.Id == id);
        }

        public bool Remove(long id)
        {
            var issuecategoryToDelete = db.IssuesCategories.SingleOrDefault(l => l.Id == id);
            if(issuecategoryToDelete != null)
            {
                db.IssuesCategories.Remove(issuecategoryToDelete);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}