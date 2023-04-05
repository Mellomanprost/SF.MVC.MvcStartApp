using Microsoft.EntityFrameworkCore;
using MVC.MvcStartApp.Models.Db.Entities;

namespace MVC.MvcStartApp.Models
{
    /// <summary>
    /// Класс контекста, предоставляющий доступ к сущностям базы данных
    /// </summary>
    public sealed class RepositoryContext : DbContext
    {
        /// Ссылка на таблицу Request
        public DbSet<Request> Requests { get; set; } = null!;

        // Логика взаимодействия с таблицами в БД
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
