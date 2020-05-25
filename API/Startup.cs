using System;
using ChoreDataModel.Context;
using ChoreDataModel.Interfaces;
using ChoreDataModel.Model;
using ChoreDataModel.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Okta.Sdk;
using Okta.Sdk.Configuration;
using Microsoft.AspNetCore.SpaServices.Extensions;

namespace API
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

            services.AddControllers();
            services.AddEntityFrameworkSqlServer().AddDbContext<ChoreContext>((options) =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ChoreContext"), b => b.MigrationsAssembly("API"));
            });
            services.AddScoped(typeof(IChoreRepository<Chore>), typeof(ChoreRepository<Chore>));
            services.AddCors(options =>
            {
                options.AddPolicy("VueCorsPolicy", builder =>
                {
                    builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .WithOrigins("http://localhost:8080");
                });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = Configuration["Okta:Authority"];
                    options.Audience = "api://default";
                });

            services.AddSingleton<IOktaClient>(new OktaClient(new OktaClientConfiguration
            {
                OktaDomain = "https://dev-736404.okta.com",
                Token = Configuration["Okta:token"]
            }));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets(Configuration["okta:token"]);
                app.UseDeveloperExceptionPage();
                
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("VueCorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            builder.Build();
        }
    }
}
