using AppData.Connection;
using AppData.Context;
using AppData.Repositories;
using AppData.UnitOfWorks;
using AppEntity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppData.Extentions
{
    public static class DataExtentions 
    {
        public static IServiceCollection AddDataExtentions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                var connnectionStrings = configuration.GetSection(ConnectionStringOption.DbKey).Get<ConnectionStringOption>();
                options.UseSqlServer(connnectionStrings!.DefaultConnection);
            });
           

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
