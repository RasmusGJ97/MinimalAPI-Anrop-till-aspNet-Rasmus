using FrontEnd_MinimalAPI.Components;
using FrontEnd_MinimalAPI.Services;

namespace FrontEnd_MinimalAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddScoped<BookService>();



            //builder.Services.AddHttpClient("MinimalApiUrl", client =>
            //{
            //    client.BaseAddress = new Uri("https://localhost:7057");
            //});

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7057") });

            //builder.Services.AddHttpClient();

            //StaticDetails.BookApiBase = builder.Configuration["Urls:MinimalApiUrl"];

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();


            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
