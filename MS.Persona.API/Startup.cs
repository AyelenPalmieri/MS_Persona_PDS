using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MS.Persona.AccessData.Commands;
using MS.Persona.AccessData.Queries;
using MS.Persona.API.Entities;
using MS.Persona.Application.Services;
using MS.Persona.Domain.Commands;
using MS.Persona.Domain.Queries;
using Services;
using SqlKata.Compilers;
using System.Data;
using System.Data.SqlClient;

namespace MS.Persona.API
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
            services.AddDbContext<MSPersonaDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("MSPersonaDb")));
            services.AddScoped<MSPersonaDbContext, MSPersonaDbContext>();

            services.AddTransient<IGenericsRepository, GenericsRepository>();
            services.AddTransient<IServiceListaHijos, ServiceListaHijos>();
            services.AddTransient<IServiceLocalidad, ServiceLocalidad>();
            services.AddTransient<IServiceProvincia, ServiceProvincia>();
            services.AddTransient<IServiceGenero, ServiceGenero>();
            services.AddTransient<IServiceEstadoCivil, ServiceEstadoCivil>();
            services.AddTransient<IServiceNacionalidad, ServiceNacionalidad>();
            services.AddTransient<IServicioPersona, ServicioPersona>();
            services.AddTransient<ILocalidadQuery, LocalidadQuery>();
            services.AddTransient<IProvinciaQuery, ProvinciaQuery>();
            services.AddTransient<IGeneroQuery, GeneroQuery>();
            services.AddTransient<IEstadoCivilQuery, EstadoCivilQuery>();
            services.AddTransient<INacionalidadQuery, NacionalidadQuery>();
            services.AddTransient<IPersonaQuery, PersonaQuery>();
            services.AddTransient<IListaHijosQuery, ListaHijosQuery>();

            services.AddTransient<Compiler, SqlServerCompiler>();
            services.AddTransient<IDbConnection>(b =>
            {
                return new SqlConnection(Configuration.GetConnectionString("MSPersonaDb"));
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddControllers();
            services.AddControllersWithViews();

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
