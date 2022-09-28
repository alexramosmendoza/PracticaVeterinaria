using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PracticaVeterinaria.app.Dominio;
using PracticaVeterinaria.app.Persistencia;
using PracticaVeterinaria.app.Persistencia.AppRepositorios;

namespace PracticaVeterinaria.app.Presentacion
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
            //Agregar RazorPages
            services.AddRazorPages();

            //Asociamos los repositorios a la capa de presentación para el uso del servicio DbContext.        
            services.AddScoped<IRepositorioHistoriaClinica, RepositorioHistoriaClinica>();
            services.AddScoped<IRepositorioMascota, RepositorioMascota>();
            services.AddScoped<IRepositorioPropietario, RepositorioPropietario>();
            services.AddScoped<IRepositorioVeterinario, RepositorioVeterinario>();
            services.AddScoped<IRepositorioVisita, RepositorioVisita>();

            //AppContext.
            //services.AddSingleton<PracticaVeterinaria.app.Persistencia.AppRepositorios>();
            services.AddSingleton<IRepositorioHistoriaClinica, RepositorioHistoriaClinica>();
            services.AddSingleton<IRepositorioMascota, RepositorioMascota>();
            services.AddSingleton<IRepositorioPropietario, RepositorioPropietario>();
            services.AddSingleton<IRepositorioVeterinario, RepositorioVeterinario>();
            services.AddSingleton<IRepositorioVisita, RepositorioVisita>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}