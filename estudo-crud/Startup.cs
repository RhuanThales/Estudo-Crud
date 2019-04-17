using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using estudo_crud.BusinessLayer;
using estudo_crud.DataAccess;
using estudo_crud.DataAccess.Dtos;
using estudo_crud.DataAccess.DataAccessObject;
using estudo_crud.DataAccess.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace estudo_crud
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
            services.Configure<Configuracoes>(
                options =>
                {
                    options.ConnectionString =
                        Configuration.GetSection("MongoDb:ConnectionString").Value;
                    options.Database = Configuration.GetSection("MongoDb:Database").Value;
                });
                        
            services.AddSingleton<IMongoClient, MongoClient>(
                _ => new MongoClient(Configuration.GetSection("MongoDb:ConnectionString").Value));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Livros",
                        Version = "v1",
                        Description = "Projeto de estudo ASP.Net Core",
                        Contact = new Contact
                        {
                            Name = "Prefeitura de Patos de Minas"
                        }
                    });
            });

            //MAPEAMENTO PARA INJECAO DE DEPENDENCIA
            services.AddScoped<IMongoContext, MongoContext>();
            services.AddScoped<ILivroDao, LivroDao>();
            services.AddScoped<ILivroBll, LivroBll>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Estudos Crud");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
