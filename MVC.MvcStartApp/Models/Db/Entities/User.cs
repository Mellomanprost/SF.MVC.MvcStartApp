using Microsoft.Extensions.Logging.Abstractions;

namespace MVC.MvcStartApp.Models.Db.Entities
{
    /// <summary>
    /// модель пользователя в блоге
    /// </summary>
    public class User
    {
        // Уникальный идентификатор сущности в базе
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime JoinDate { get; set; }
    }
}
