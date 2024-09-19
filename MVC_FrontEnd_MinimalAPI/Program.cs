using FrontEnd_MinimalAPI;
using MinimalAPI_Anrop_till_aspNet_Rasmus.Repository;
using MVC_FrontEnd_MinimalAPI.Services;

namespace MVC_FrontEnd_MinimalAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddHttpClient();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            StaticDetails.BookApiBase = builder.Configuration["Urls:MinimalApiUrl"];

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

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
