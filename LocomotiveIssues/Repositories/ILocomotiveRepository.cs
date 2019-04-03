using LocomotiveIssues.Models.Locomotive;
using System.Collections.Generic;


namespace LocomotiveIssues.Repositories
{
    public interface ILocomotiveRepository
    {
        IEnumerable<LocomotiveModel> GetAllLocomotives();
        long AddLocomotive(AddLocomotiveModel model);
        void EditLocomotive(EditLocomotiveModel model);
        bool Remove(long id);
        EditLocomotiveModel GetLocomotiveById(long id);

    }
}
