using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using OnboardingSIGDB1.Data;
using System;
using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Data.Repositorios;
using AutoMapper;

namespace OnboardingSIGDB1.IOC
{
    public static class StartupIOC
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options => 
                options.UseSqlServer(configuration["ConnectionString"]));

            services.AddScoped(typeof (IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IEmpresaRepository), typeof(EmpresaRepository));
            services.AddAutoMapper(typeof(StartupIOC));
            
        }
    }
}
