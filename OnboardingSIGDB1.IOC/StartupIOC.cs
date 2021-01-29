using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using OnboardingSIGDB1.Data;
using System;
using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Data.Repositorios;
using AutoMapper;
using OnboardingSIGDB1.Domain.Services;
using OnboardingSIGDB1.Domain.Notifications;
using OnboardingSIGDB1.Domain.Services.Consulta;

namespace OnboardingSIGDB1.IOC
{
    public static class StartupIOC
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options => 
                options.UseSqlServer(configuration["ConnectionString"]));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IEmpresaRepository), typeof(EmpresaRepository));
            services.AddScoped(typeof(ICargoRepository), typeof(CargoRepository));
            services.AddScoped(typeof(IFuncionarioRepository), typeof(FuncionarioRepository));

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddScoped<NotificationContext>();

            services.AddScoped(typeof(IEmpresaConsulta), typeof(EmpresaConsulta));
            services.AddScoped(typeof(IFuncionarioConsulta), typeof(FuncionarioConsulta));            

            services.AddScoped(typeof(IArmazenadorDeEmpresa), typeof(ArmazenadorDeEmpresa));
            services.AddScoped(typeof(IArmazenadorDeCargo), typeof(ArmazenadorDeCargo));
            services.AddScoped(typeof(IArmazenadorDeFuncionario), typeof(ArmazenadorDeFuncionario));

            services.AddScoped(typeof(IExclusaoDeEmpresa), typeof(ExclusaoDeEmpresa));
            services.AddScoped(typeof(IExclusaoDeCargo), typeof(ExclusaoDeCargo));
            services.AddScoped(typeof(IExclusaoDeFuncionario), typeof(ExclusaoDeFuncionario));

            services.AddScoped(typeof(IVinculacaoDeFuncionarioACargo), typeof(VinculacaoDeFuncionarioACargo));
            services.AddScoped(typeof(IVinculacaoDeFuncionarioAEmpresa), typeof(VinculacaoDeFuncionarioAEmpresa));

            services.AddAutoMapper(typeof(StartupIOC));
        }
    }
}
