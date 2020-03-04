using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using hackathon_backdotnet_g1.Models;

namespace hackathon_backdotnet_g1
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
            services.AddCors();

            // Runs in docker - comment to run dotnet ef commands
            services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")));

            // Runs in memory
            // services.AddEntityFrameworkNpgsql().AddDbContext<DatabaseContext>(opt =>
            //     opt.UseInMemoryDatabase(Configuration.GetConnectionString("DatabaseContext")));

            // Runs in local server - uncomment to run dotnet ef commands
            // services.AddEntityFrameworkNpgsql().AddDbContext<DatabaseContext>(opt =>
            //     opt.UseNpgsql(Configuration.GetConnectionString("DatabaseContext")));

            services.AddControllers();
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

            app.UseCors(option => option.AllowAnyOrigin());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
