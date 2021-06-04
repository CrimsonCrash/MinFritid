using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MinFritidAPI.Data;
using MinFritidAPI.Helpers;

namespace MinFritidAPI
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
            //adding the cors policy that allows data to move between different entities
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {

                        builder.WithOrigins("http://localhost:4200");

                    });

                options.AddPolicy("AnotherPolicy",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200").AllowAnyOrigin()
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });

            });

            // Forbind til databasen
            services.AddDbContext<MinFritidContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            

            

            // Configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(appSettings.SessionTimeout);
                options.Cookie.HttpOnly = true;
            });

            services.AddMvc();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AnotherPolicy");
            app.UseSession();
            app.UseMvc();
            
        }
    }
}
