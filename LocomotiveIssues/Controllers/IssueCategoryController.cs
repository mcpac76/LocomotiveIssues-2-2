using LocomotiveIssues.Models.IssueCategory;
using LocomotiveIssues.Repositories;
using System.Web.Mvc;

namespace LocomotiveIssues.Controllers
{
    public class IssueCategoryController : Controller
    {
        private readonly IIssueCategoryRepository _repository = new IssueCategoryRepository();
        
        [HttpGet]
        public ActionResult List()
        {
            var issuescategories = _repository.GetAllIssuesCategories();
            return View(issuescategories);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new AddIssueCategoryModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddIssueCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.AddIssueCategory(model);
                return RedirectToAction("List");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var model = _repository.GetIssueCategoryById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditIssueCategoryModel model)
        {
            _repository.EditIssueCategory(model);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            var model = new DeleteIssueCategoryModel() { Id = id };
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(DeleteIssueCategoryModel model)
        {
            _repository.Remove(model.Id);
            return RedirectToAction("List");
        }
    }
}