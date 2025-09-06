using Microsoft.Extensions.DependencyInjection;
using MyBookOfRecipes.Application.Mappings.UserMapping;
using MyBookOfRecipes.Application.Services.UserServices;

namespace MyBookOfRecipes.Application.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddScoped<IRegisterUserService, RegisterUserService>();

            return services;
        }

        private static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            return services.AddAutoMapper(typeof(RequestToDomainMapping).Assembly);
        }
    }
}
