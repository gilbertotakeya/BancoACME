﻿using BancoACME.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;

namespace BancoACME.API.Calculadora
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<ICalculadora, BancoACME.Servicos.Calculadora>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Banco ACME - API - Calculadora Online",
                        Version = "v1",
                        Description = "Banco ACME - API - Calculadora Online Financeira",
                        Contact = new Contact
                        {
                            Name = "Gilberto Junior",
                            Url = "https://www.eficazti.com.br",
                            Email = "gilbertotakeya@yahoo.com.br"
                        }
                    });
                c.CustomSchemaIds(x => x.FullName); //Essa linha deve ser inserida em casos que há classes com mesmo nome em namespaces diferentes

                //Obtendo o diretório e depois o nome do arquivo .xml de comentários
                var applicationBasePath = PlatformServices.Default.Application.ApplicationBasePath;
                var applicationName = PlatformServices.Default.Application.ApplicationName;
                var xmlDocumentPath = Path.Combine(applicationBasePath, $"{applicationName}.xml");

                //Caso exista arquivo então adiciona-lo
                if (File.Exists(xmlDocumentPath))
                {
                    c.IncludeXmlComments(xmlDocumentPath);
                }
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Habilitar o middleware para servir o swagger-ui (HTML, JS, CSS, etc.), 
            // Especificando o Endpoint JSON Swagger.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Banco ACME - API - Calculadora Online Financeira");
                c.RoutePrefix = string.Empty; //Adicione algum proefixo da URL caso queira
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            
        }
    }
}
