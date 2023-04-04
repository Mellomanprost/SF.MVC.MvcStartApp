using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.MvcStartApp.Models.Db.Entities;
using MVC.MvcStartApp.Models.Db.Repositories;


namespace MVC.MvcStartApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IBlogRepository _repo;

        public UsersController(IBlogRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User newUser)
        {
            await _repo.AddUser(newUser);
            return View(newUser);
        }

        public async Task<IActionResult> Users()
        {
            var authors = await _repo.GetUsers();

            return View(authors);
        }
    }
}
