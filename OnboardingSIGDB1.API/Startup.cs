using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Notifications;
using OnboardingSIGDB1.IOC;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSIGDB1.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            StartupIOC.ConfigureServices(services, Configuration);

            services.AddMvc(options => options.Filters.Add<NotificationFilter>())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "OnboardingSIGDB1-API", Version = "version 1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder
                       .AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowCredentials();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                await next.Invoke();

                var unitOfWork = (IUnitOfWork)context.RequestServices.GetService(typeof(IUnitOfWork));
                await unitOfWork.Commit();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("./swagger/v1/swagger.json", "OnboardingSIGDB1.API");
                    c.RoutePrefix = String.Empty;
                });
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();


            app.UseMvc();
        }
    }
}
