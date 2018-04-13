﻿using System;
using AutoMapper;
using BlogSystem.Data;
using BlogSystem.Data.Models;
using BlogSystem.Data.Repository;
using BlogSystem.Data.Saver;
using BlogSystem.Infrastructure.Mapping;
using BlogSystem.Services.Data;
using BlogSystem.Services.Data.Contracts;
using BlogSystem.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogSystem.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            this.Configuration = configuration;
            this.Environment = env;
        }

        public IConfiguration Configuration { get; }

        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            this.RegisterData(services);
            this.RegisterAuthentication(services);
            this.RegisterServices(services);
            this.RegisterInfrastructure(services);
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IPostsService, PostsService>();
            services.AddTransient<ICommentsService, CommentsService>();
        }

        private void RegisterInfrastructure(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAutoMapper();

            services.AddScoped<IMappingProvider, MappingProvider>();
        }
        private void RegisterAuthentication(IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<BlogSystemDbContext>()
                .AddDefaultTokenProviders();

            if (this.Environment.IsDevelopment())
            {
                services.Configure<IdentityOptions>(options =>
                {
                    // Password settings
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 3;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequiredUniqueChars = 0;

                    // Lockout settings
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(1);
                    options.Lockout.MaxFailedAccessAttempts = 999;
                });
            }            
        }

        private void RegisterData(IServiceCollection services)
        {
            services.AddDbContext<BlogSystemDbContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });
            
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<ISaver, EntitySaver>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (this.Environment.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
