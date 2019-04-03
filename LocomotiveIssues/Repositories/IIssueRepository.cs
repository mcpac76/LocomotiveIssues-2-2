using LocomotiveIssues.Models.Issue;
using System.Collections.Generic;

namespace LocomotiveIssues.Repositories
{
    public interface IIssueRepository
    {
        IEnumerable<IssueModel> GetAllIssues();
        long AddIssue(AddIssueModel model);
        void EditIssue(EditIssueModel model);
        EditIssueModel GetIssueById(long id);

    }

}
