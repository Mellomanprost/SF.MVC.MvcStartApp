using Microsoft.AspNetCore.Mvc;
using MVC.MvcStartApp.Models.Db.Entities;
using MVC.MvcStartApp.Models.Db.Repositories;
using MVC.MvcStartApp.Models;
using System.Diagnostics;

namespace MVC.MvcStartApp.Controllers
{
    public class RequestsController : Controller
    {
        // ссылка на репозиторий
        private readonly IRequestRepository _repo;
        private readonly ILogger<HomeController> _logger;


        public RequestsController(ILogger<HomeController> logger, IRequestRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        //// Сделаем метод асинхронным
        //public async Task<IActionResult> RequestHistory()
        //{
        //    return View();
        //}

        //[HttpGet]
        //public IActionResult Register()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Register(Request newRequest)
        //{
        //    await _repo.AddRequest(newRequest);
        //    return View(newRequest);
        //}

        public async Task<IActionResult> Requests()
        {
            var requests = await _repo.GetRequests();

            return View(requests);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
