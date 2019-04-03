using LocomotiveIssues.Models.User;
using System.Collections.Generic;


namespace LocomotiveIssues.Repositories
{
    interface IUserRepository
    {
        IEnumerable<UserModel> GetAllUsers();
        long AddUser(AddUserModel model);
        void EditUser(EditUserModel model);
        bool Remove(long id);
        EditUserModel GetUserById(long id);
    }
}
