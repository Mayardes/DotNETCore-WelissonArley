
using MyBookOfRecipes.API.Filters;
using MyBookOfRecipes.API.Middlewares;
using MyBookOfRecipes.Application.Mappings.UserMapping;
using MyBookOfRecipes.Application.Services.UserServices;
using System.Reflection;

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
            builder.Services.AddAutoMapper(typeof(RequestToDomainMapping).Assembly);
            builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();

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
