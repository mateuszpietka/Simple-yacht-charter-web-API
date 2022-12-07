using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using YachtCharterWebApp.Application.Services;
using YachtCharterWebApp.Core.Repositories;
using YachtCharterWebApp.Core.Services;
using YachtCharterWebApp.Infrastructure.Context;
using YachtCharterWebApp.Infrastructure.Repositories;
using YachtCharterWebApp.Infrastructure.Seeder;

namespace YachtCharterWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddScoped<YachtAppSeeder>();
            services.AddScoped<IYachtRepository, YachtRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddDbContext<YachtsAppDbContext>
                (options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=YachtAppDb;Trusted_Connection=True"));
            services.AddCors(options =>
            {
                options.AddPolicy("FrontEndClient", builider =>
                    builider.AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("FrontEndClient");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            var scope = app.ApplicationServices.CreateScope();
            var yachtAppSeeder = scope.ServiceProvider.GetRequiredService<YachtAppSeeder>();
            yachtAppSeeder.Seed();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
