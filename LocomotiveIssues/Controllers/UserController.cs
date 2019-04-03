using LocomotiveIssues.Models.User;
using LocomotiveIssues.Repositories;
using System.Web.Mvc;

namespace LocomotiveIssues.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _repository = new UserRepository();

        [HttpGet]
        public ActionResult List()
        {
            var users = _repository.GetAllUsers();
            return View(users);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new AddUserModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddUserModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.AddUser(model);
                return RedirectToAction("List");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var model = _repository.GetUserById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditUserModel model)
        {
            _repository.EditUser(model);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            var model = new DeleteUserModel() { Id = id };
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(DeleteUserModel model)
        {
            _repository.Remove(model.Id);
            return RedirectToAction("List");
        }
    }
}