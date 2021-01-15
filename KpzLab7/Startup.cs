using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KpzLab7.DAO;
using KpzLab7.Repository.Rooms;
using KpzLab7.Repository.Users;
using KpzLab7.SourceModel.Rooms;
using KpzLab7.SourceModel.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace KpzLab7
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
            services.AddDbContext<KpzLab7Context>();
            services.AddControllers();

            services.AddScoped<IUsersSourceModel, UsersSourceModel>();
            services.AddScoped<IUsersRepository, UsersRepository>();


            services.AddScoped<IRoomsSourceModel, RoomsSourceModel>();
            services.AddScoped<IRoomsRepository, RoomsRepository>();

            services.AddSwaggerGen();
            //services.AddScoped<, > ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
