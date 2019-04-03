using LocomotiveIssues.Models.Locomotive;
using LocomotiveIssues.Repositories;
using System.Web.Mvc;

namespace LocomotiveIssues.Controllers
{
    public class LocomotiveController : Controller
    {
        private readonly ILocomotiveRepository _repository = new LocomotiveRepository();

        [HttpGet]
        public ActionResult List()
        {
            var locomotives = _repository.GetAllLocomotives();    
            return View(locomotives);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new AddLocomotiveModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddLocomotiveModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.AddLocomotive(model);
                return RedirectToAction("List");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var model = _repository.GetLocomotiveById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditLocomotiveModel model)
        {
            _repository.EditLocomotive(model);
            return RedirectToAction("List");
        }
        
        [HttpGet]
        public ActionResult Delete(long id)
        {
            var model = new DeleteLocomotiveModel() { Id = id };
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(DeleteLocomotiveModel model)
        {
            _repository.Remove(model.Id);
            return RedirectToAction("List");
        }
    }
}