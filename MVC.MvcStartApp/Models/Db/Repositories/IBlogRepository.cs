using MVC.MvcStartApp.Models.Db.Entities;

namespace MVC.MvcStartApp.Models.Db.Repositories
{
    public interface IBlogRepository
    {
        Task AddUser(User user);

        Task<User[]> GetUsers();
    }
}
