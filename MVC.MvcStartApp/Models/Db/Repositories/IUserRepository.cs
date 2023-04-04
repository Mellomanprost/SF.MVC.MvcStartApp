using MVC.MvcStartApp.Models.Db.Entities;

namespace MVC.MvcStartApp.Models.Db.Repositories
{
    public interface IUserRepository
    {
        Task AddUser(User user);
    }
}
