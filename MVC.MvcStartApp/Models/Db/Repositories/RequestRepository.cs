using Microsoft.EntityFrameworkCore;
using MVC.MvcStartApp.Models.Db.Entities;

namespace MVC.MvcStartApp.Models.Db.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly RequestContext _context;

        public RequestRepository(RequestContext context)
        {
            _context = context;
        }

        public async Task AddRequest(Request request)
        {
            //request.Date = DateTime.Now;  Вроде не нужно это
            //request.Id = Guid.NewGuid();

            // Добавление запроса
            var entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);

            // Сохранение изенений
            await _context.SaveChangesAsync();
        }
    }
}
