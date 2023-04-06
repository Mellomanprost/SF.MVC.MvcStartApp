﻿using Microsoft.EntityFrameworkCore;
using MVC.MvcStartApp.Models.Db.Entities;

namespace MVC.MvcStartApp.Models.Db.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        // ссылка на контекст
        private readonly BlogContext _context;

        // Метод-конструктор для инициализации
        public RequestRepository(BlogContext context)
        {
            _context = context;
        }

        // Метод для добавления запроса в бд
        public async Task AddRequest(Request request)
        {
            //request.Date = DateTime.Now;
            //request.Id = Guid.NewGuid();

            // Добавление запроса
            var entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);

            // Сохранение изенений
            await _context.SaveChangesAsync();
        }

        public async Task<Request[]> GetRequests()
        {
            // Получим всех активных пользователей
            return await _context.Requests.ToArrayAsync();
        }
    }
}
