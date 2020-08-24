using System;
using Identity.Infrastructure.Constants;
using Identity.Infrastructure.Data;
using Identity.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Infrastructure.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddIdentityDbContext(this IServiceCollection services, string connectionString = null)
        {
            connectionString = string.IsNullOrEmpty(connectionString) ? App.Configuration.GetConnectionString(Database.ConnectionStringKey) : connectionString;
            services.AddDbContext<IdentityDbContext>(options =>
                options.UseNpgsql(connectionString));
            return services;
        }
    }
}