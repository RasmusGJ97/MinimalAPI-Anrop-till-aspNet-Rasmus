
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MinimalAPI_Anrop_till_aspNet_Rasmus.Data;
using MinimalAPI_Anrop_till_aspNet_Rasmus.EndPoint;
using MinimalAPI_Anrop_till_aspNet_Rasmus.Repository;

namespace MinimalAPI_Anrop_till_aspNet_Rasmus
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(MappingConfig));
            builder.Services.AddValidatorsFromAssemblyContaining<Program>();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionToDB")));

            builder.Services.AddScoped<IBookRepository, BookRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.ConfigurationBookEndpoints();


            app.Run();
        }
    }
}
