using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SiteMercado.Api.Produtos.Db;
using SiteMercado.Api.Produtos.Providers;

namespace SiteMercado.Produtos
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
            services.AddCors(OptionsBuilderConfigurationExtensions => OptionsBuilderConfigurationExtensions.AddPolicy("Cors", builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));
            services.AddScoped<IProdutosProvider, ProviderProdutos>();
            services.AddAutoMapper(typeof(Startup));
            //services.AddDbContext<ProdutosDbContext>(options =>
            //{
            //    options.UseInMemoryDatabase("Products");
            //});

            services.AddDbContext<SiteMercadoContext>(options =>
                    options.UseSqlServer(
                        this.Configuration.GetConnectionString("DefaultProdutos")));


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SiteMercadoContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                context.Database.EnsureCreated();
            }

            app.UseCors("Cors");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
