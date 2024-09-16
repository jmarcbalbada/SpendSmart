using Microsoft.EntityFrameworkCore;
using SpendSmart.Models;

namespace SpendSmart
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Add Swagger services
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<SpendSmartDbContext>(options =>
                options.UseInMemoryDatabase("SpendSmartDb")
            );


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                // Enable Swagger in development mode
                app.UseSwagger(); 
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SpendSmart API v1"));  // <-- Add this line for the Swagger UI
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
