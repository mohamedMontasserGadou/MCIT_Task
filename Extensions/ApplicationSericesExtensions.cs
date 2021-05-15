using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MCIT_Task.Infrastructure.DBContext;
using MCIT_Task.Infrastructure.UOW;
using MCIT_Task.Services.Implementation;
using MCIT_Task.Services.Interfaces;
using MCIT_Task.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MCIT_Task.Extensions
{
    public static class ApplicationSericesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(config.GetConnectionString("Default")));
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

            return services;

        }
    }
}
