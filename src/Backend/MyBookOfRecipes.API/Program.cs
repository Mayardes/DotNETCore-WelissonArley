
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MyBookOfRecipes.API.Filters;
using MyBookOfRecipes.API.Middlewares;
using MyBookOfRecipes.Application.Extensions;
using MyBookOfRecipes.Application.Mappings.UserMapping;
using MyBookOfRecipes.Application.Services.UserServices;
using MyBookOfRecipes.Domain.Repositories.UserRepository;
using MyBookOfRecipes.Domain.UnitOfWork;
using MyBookOfRecipes.Infrastructure.Data;
using MyBookOfRecipes.Infrastructure.Extensions;
using MyBookOfRecipes.Infrastructure.Repositories.UserRepository;
using MyBookOfRecipes.Infrastructure.UnitOfWork;
using System.Data;

namespace MyBookOfRecipes.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<ExceptionFilter>();
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<CultureMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
