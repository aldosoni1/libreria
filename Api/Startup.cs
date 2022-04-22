using Api.Configurations;
using Application;
using Application.Services;
using Domain.Models.Repositories;
using Infraestructure;
using Infraestructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PJENL.Shared.Kernel.Configurations.Configurations;
using PJENL.Shared.Kernel.Middleware;
using PJENLShared.Kernel.Auth;
using PJENLShared.Kernel.Auth.ExternalServices;

namespace Api
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
            services.AddConfigurationAuth(Configuration);
            services.AddSingleton<IConfiguration>(provider => Configuration);
            services.AddHttpContextAccessor();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IHubService, HubService>();
            services.AddScoped<IUserInfoService, UserInfoService>();

            services.AddControllers();
            services.AddConfigurationDba(Configuration);
            services.AddScoped<ILibroRepository, LibroRepository>();
            services.AddScoped<ILibreriaRepository, LibreriaRepository>();
            services.AddScoped<ILibroService, LibroService>();
            services.AddScoped<ILibreriaService, LibreriaService>();
           
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
            });
            
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseConfigurationAuth();
            app.UseAuthorization();
            app.UseConfigurationCors();
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
