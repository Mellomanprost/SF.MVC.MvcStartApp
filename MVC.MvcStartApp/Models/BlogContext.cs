using Microsoft.EntityFrameworkCore;
using MVC.MvcStartApp.Models.Db.Entities;

namespace MVC.MvcStartApp.Models
{
    /// <summary>
    /// Класс контекста, предоставляющий доступ к сущностям базы данных
    /// </summary>
    public sealed class BlogContext : DbContext
    {
        /// Ссылка на таблицу Users
        public DbSet<User> Users { get; set; } = null!;

        /// Ссылка на таблицу UserPosts
        public DbSet<UserPost> UserPosts { get; set; } = null!;

        /// Ссылка на таблицу Requests
        public DbSet<Request> Requests { get; set; } = null!;

        // Логика взаимодействия с таблицами в БД
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
