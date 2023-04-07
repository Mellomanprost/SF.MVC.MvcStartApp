using MVC.MvcStartApp.Models.Db.Entities;
using MVC.MvcStartApp.Models.Db.Repositories;
using static System.Net.Mime.MediaTypeNames;

namespace MVC.MvcStartApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestRepository _request;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next, IRequestRepository request)
        {
            _next = next;
            _request = request;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            // Для логирования данных о запросе используем свойста объекта HttpContext
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");

            string urlAdress = $"http://{context.Request.Host.Value + context.Request.Path}";

            var newUrl = new Request()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = urlAdress
            };

            // Добавление url в бд
            await _request.AddRequest(newUrl);

            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}
