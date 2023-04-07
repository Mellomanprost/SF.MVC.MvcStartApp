using Microsoft.AspNetCore.Mvc;
using MVC.MvcStartApp.Models.Db.Repositories;

namespace MVC.MvcStartApp.Controllers
{
    public class LogsController : Controller
    {
        // ссылка на репозиторий
        private readonly IRequestRepository _repo;

        public LogsController(IRequestRepository repo)
        {
            _repo = repo;
        }

        // Сделаем метод асинхронным
        public async Task<IActionResult> Index()
        {
            var requests = await _repo.GetRequests();

            return View(requests);
        }
    }
}
