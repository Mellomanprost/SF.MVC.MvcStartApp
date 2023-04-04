using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MVC.MvcStartApp.Middlewares;
using MVC.MvcStartApp.Models;
using MVC.MvcStartApp.Models.Db.Repositories;

namespace MVC.MvcStartApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // �������� ������ ����������� �� ����� ������������
            string connection = builder.Configuration.GetConnectionString("DefaultConnection");

            // ��������� �������� ApplicationContext � �������� ������� � ����������
            builder.Services.AddDbContext<BlogContext>(options => options.UseSqlServer(connection));
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IBlogRepository, BlogRepository>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // ���������� ����������� � �������������� �� �������������� ����
            app.UseMiddleware<LoggingMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}