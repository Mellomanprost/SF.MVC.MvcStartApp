using Microsoft.EntityFrameworkCore;
using MVC.MvcStartApp.Models.Db.Entities;
using MVC.MvcStartApp.Models.Db.Repositories;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace MVC.MvcStartApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestRepository _repository;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next, IRequestRepository repository)
        {
            _next = next;
            _repository = repository;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            string requestUrl = $"http://{context.Request.Host.Value + context.Request.Path}";

            var newRequest = new Request()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = requestUrl
            };

            await _repository.AddRequest(newRequest);

            LogConsole(context);
            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }

        public void LogConsole(HttpContext context)
        {
            // Для логирования данных о запросе используем свойста объекта HttpContext
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
        }
    }
}
