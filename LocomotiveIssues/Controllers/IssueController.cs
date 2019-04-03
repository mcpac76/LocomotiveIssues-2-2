using LocomotiveIssues.Models.Issue;
using LocomotiveIssues.Repositories;
using System.Web.Mvc;

namespace LocomotiveIssues.Controllers
{
    public class IssueController : Controller
    {
        private readonly IIssueRepository _repository = new IssueRepository();
        
        
        [HttpGet]
        public ActionResult List()
        {
            var issues = _repository.GetAllIssues();
            return View(issues);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new AddIssueModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddIssueModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.AddIssue(model);
                return RedirectToAction("List");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var model = _repository.GetIssueById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditIssueModel model)
        {
            _repository.EditIssue(model);
            return RedirectToAction("List");
        }    
    }
}