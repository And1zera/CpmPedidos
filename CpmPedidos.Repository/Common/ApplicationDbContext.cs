using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;

namespace CpmPedidos.Repository
{
    public class ApplicationDbContext : DbContext // -> Herdando a classe DbContext do Entity Framework
    {
        // Para cada entidade criar um DbSet para acessar a entidade de pedidos via DbContext (Sempre no Plural)
        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<CategoriaProduto> CategoriaProdutos { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<PromocaoProduto> PromocoesProdutos { get; set; }
        public virtual DbSet<Combo> Combos { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }

        // Metodo para criar o model e fazer a carga do mapeamento do Assembly
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        // Contrutor -> duvida
        public ApplicationDbContext()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        // Construtor passando as options para a base do DbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
    }
}
