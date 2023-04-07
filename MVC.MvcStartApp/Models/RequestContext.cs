using Microsoft.EntityFrameworkCore;
using MVC.MvcStartApp.Models.Db.Entities;

namespace MVC.MvcStartApp.Models
{
    /// <summary>
    /// Класс контекста, предоставляющий доступ к сущностям базы данных
    /// </summary>
    public sealed class RequestContext : DbContext
    {
        /// Ссылка на таблицу Request
        public DbSet<Request> Requests { get; set; } = null!;

        // Логика взаимодействия с таблицами в БД
        public RequestContext(DbContextOptions<RequestContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Request>().ToTable("Requests");
        }
    }
}
