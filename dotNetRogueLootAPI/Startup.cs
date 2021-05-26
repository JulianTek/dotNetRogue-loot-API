using dotNetRogueLootAPI.Application.Interfaces;
using dotNetRogueLootAPI.Application.Repositories;
using dotNetRogueLootAPI.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace dotNetRogueLootAPI.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContextPool<IAppDbContext, AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("WeaponsDb")));
            services.AddScoped<IWeaponTypeRepository, WeaponTypeRepository>();
            services.AddScoped<IWeaponRarityRepository, WeaponRarityRepository>();
            services.AddScoped<IEffectRepository, EffectRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
