using Microsoft.Extensions.DependencyInjection;

namespace CpmPedidos.API
{
    public class DependencyInjection // Classe para fazer a associação entre a Interface e a Classe Concreta
    {
        // Metodo para fazer os registros dos services da classe startup
        public static void Register(IServiceCollection serviceProvider)
        {
            RepositoryDependence(serviceProvider);
        }

        // Metodo onde vamos colocar todas as injeções de dependencias dos nossos repositories 
        // EX .. serviceProvider.AddScoped<interface, class>();
        private static void RepositoryDependence(IServiceCollection serviceProvider)
        {
            
        }
    }
}
