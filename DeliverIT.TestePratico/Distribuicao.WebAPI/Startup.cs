using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacao.Principal.Interfaces;
using Aplicacao.Principal.Servicos;
using AutoMapper;
using Dominio.Principal.Entidades;
using Dominio.Principal.Interfaces.Repositorios;
using Dominio.Principal.Interfaces.Servicos;
using Dominio.Servicos.Servicos;
using Infra.Dados.DTO.Mapeamento.Mappers;
using Infra.Dados.Principal.DbContexto;
using Infra.Dados.Principal.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Distribuicao.WebAPI
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
            services.AddDbContext<DbContextTeste>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers()
                    .AddNewtonsoftJson();
                        
            ConfigureServicesEx(services);
            ConfigureMappers(services);

            services.AddMvc();
        }

        private void ConfigureServicesEx(IServiceCollection services)
        {   
            services.AddScoped<IServicoContasPagar, ServicoContasPagar>();
            services.AddScoped<IAppContasPagar, AppContasPagar>();
            services.AddScoped<IRepositorioContasPagar, RepositorioContasPagar>();
        }

        private void ConfigureMappers(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperContasPagar());
                mc.AddProfile(new MapperContasPagarBaixa());                
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
                
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
