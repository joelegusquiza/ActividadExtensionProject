﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationContext;
using Core.AutoMapper;
using Core.DAL.Interfaces;
using Core.DAL.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ActividadExtensionProject
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
			services.AddSession();
			services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton(x => Configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<IActasEU, ActasEUService>();
            services.AddSingleton<IEstudiantes, EstudiantesService>();
            services.AddSingleton<ICategorias, CategoriasService>();
            services.AddSingleton<ISubCategorias, SubCategoriasService>();
            services.AddSingleton<ICarreras, CarrerasService>();
            services.AddSingleton<IReportes, ReportesService>();
			services.AddSingleton<IUsuarios, UsuariosService>();
			services.AddAuthorization(opts =>
			{
				
				opts.AddPolicy("Admin", x => x.RequireRole("Admin"));
			});
			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(opts =>
				{
					opts.LoginPath = new PathString("/Shared/Login/Index");
					opts.AccessDeniedPath = new PathString("/Shared/Login/Index");
					opts.LogoutPath = new PathString("/Shared/Login/Index");
					opts.SlidingExpiration = true;
				});
			return services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ActaEUProfile>();
                cfg.AddProfile<CategoriaProfile>();
                cfg.AddProfile<EstudianteProfile>();
                cfg.AddProfile<CarreraProfile>();
				cfg.AddProfile<UsuariosProfile>();
			});
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
			app.UseAuthentication();
			app.UseStaticFiles();
			app.UseSession();
			app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{area=Shared}/{controller=Login}/{action=Index}");
            });
        }
    }
}
