using EasyWallet.Categories.Api.Abstractions;
using EasyWallet.Categories.Api.Filters;
using EasyWallet.Categories.Api.Middlewares;
using EasyWallet.Categories.Api.Services;
using EasyWallet.Categories.Business.Abstractions;
using EasyWallet.Categories.Business.Services;
using EasyWallet.Categories.Data;
using EasyWallet.Categories.Data.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace EasyWallet.Categories.Api
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
            services.AddDbContextPool<CategoriesContext>(o => {
                var version = new MySqlServerVersion(new Version(5, 7));
                o.UseMySql(Configuration["ConnectionString"], version);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddScoped<IErrorService, ErrorService>();

            services.AddControllers(o => o.Filters.Add<ErrorHandlerFilter>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<ApiKeyMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
