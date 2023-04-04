//using Microsoft.EntityFrameworkCore;
//using MVC.MvcStartApp.Models.Db.Entities;

//namespace MVC.MvcStartApp.Models.Db.Repositories
//{
//    public class UserRepository : IUserRepository
//    {
//        // ссылка на котенкст
//        private readonly BlogContext _context;

//        // Метод-конструктор для инициализации
//        public UserRepository(BlogContext context)
//        {
//            _context = context;
//        }

//        public async Task AddUser(User user)
//        {
//            // Добавление пользователя
//            var entry = _context.Entry(user);
//            if (entry.State == EntityState.Detached)
//                await _context.Users.AddAsync(user);

//            // Сохранение изенений
//            await _context.SaveChangesAsync();
//        }
//    }
//}
