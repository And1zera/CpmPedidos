using CpmPedidos.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data.Common;

namespace CpmPedidos.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        // Propriedade de DbConnection inicializando com NpgsqlConnection passando a ConnectionString
        public DbConnection DbConection => new NpgsqlConnection(Configuration.GetConnectionString("App"));

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // Aqui Declaramos a classe DependencyInjection chamando o metodo Register() para registrar os services passados por parametro
            DependencyInjection.Register(services);

            // Injetando a informações do contexto nos services para ficar acessivel para qualquer classe
            // Definimos qual sera o contexto do banco de dados 'ApplicationDbContext'
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql( // -> Definindo o banco
                    DbConection, // -> Passando a ConnectionString
                    assembly => assembly.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)); // -> Definindo onde estao as migrations 
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
