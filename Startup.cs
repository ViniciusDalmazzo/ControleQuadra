using ApiMySql.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace ApiMySql
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Engenharia de Software - Projeto Quadra API", Version = "v1" });
            });

            services.AddScoped<IJogadorRepository>(factory =>
            {
                return new JogadorRepository(Configuration.GetConnectionString("MySqlDbConnection"));
            });

            services.AddScoped<IQuadraRepository>(factory =>
            {
                return new QuadraRepository(Configuration.GetConnectionString("MySqlDbConnection"));
            });

            services.AddScoped<IAgendamentoRepository>(factory =>
            {
                return new AgendamentoRepository(Configuration.GetConnectionString("MySqlDbConnection"));
            });

            services.AddScoped<IGrupoRepository>(factory =>
            {
                return new GrupoRepository(Configuration.GetConnectionString("MySqlDbConnection"));
            });

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.WithOrigins("https://agendamento-form.herokuapp.com/"));
                c.AddPolicy("AllowOrigin", options => options.WithOrigins("http://localhost:3000"));
            });
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

            // Configurações do Swagger no pipiline de execução da aplicação.
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto Quadra API - .NET Core");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseCors(options => options.WithOrigins("https://agendamento-form.herokuapp.com/"));
            app.UseCors(options => options.WithOrigins("http://localhost:3000"));

            app.UseMvc();
        }
    }
}
