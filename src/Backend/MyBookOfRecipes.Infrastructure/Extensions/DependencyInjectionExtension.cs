using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBookOfRecipes.Domain.Repositories.UserRepository;
using MyBookOfRecipes.Domain.UnitOfWork;
using MyBookOfRecipes.Infrastructure.Data;
using MyBookOfRecipes.Infrastructure.Repositories.UserRepository;
using System.Data;

namespace MyBookOfRecipes.Infrastructure.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //using var provider = services.BuildServiceProvider();
            //var configuration = provider.GetRequiredService<IConfiguration>();

            services.AddDbContext<MyBookOfRecipesDbContext>(x => x.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IDbConnection>(x => new SqliteConnection(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<IUserReadOnlyRepository, UserReadOnlyRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            return services;
        }
    }
}
