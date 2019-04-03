using LocomotiveIssues.Models.IssueCategory;
using System.Collections.Generic;


namespace LocomotiveIssues.Repositories
{
    interface IIssueCategoryRepository
    {
        IEnumerable<IssueCategoryModel> GetAllIssuesCategories();
        long AddIssueCategory(AddIssueCategoryModel model);
        void EditIssueCategory(EditIssueCategoryModel model);
        bool Remove(long id);
        EditIssueCategoryModel GetIssueCategoryById(long id);
    }
}
