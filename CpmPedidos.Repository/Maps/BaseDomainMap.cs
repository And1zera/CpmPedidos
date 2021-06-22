using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository
{
    // Classe Base para o map (Configuration) Extendendo o IEntityTypeConfiguration<TDomain> e a Entidade Base é TDomain
    public class BaseDomainMap<TDomain> : IEntityTypeConfiguration<TDomain> where TDomain : Base
    {
        // Propriedade privada para receber o nome da tabela
        private readonly string _nomeTabela;

        // Constutor
        public BaseDomainMap(string nomeTabela)
        {
            _nomeTabela = nomeTabela;
        }

        // Configuração com a validação do nome da tabela
        public virtual void Configure(EntityTypeBuilder<TDomain> builder)
        {
            if (!string.IsNullOrEmpty(_nomeTabela))
                builder.ToTable(_nomeTabela);

            // Definindo as Propriedades da entidade Base 
            // ID
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd(); // Definindo que a coluna irá ser gerada automaticamente

            // Criado em
            builder.Property(x => x.CriadoEm).HasColumnName("criado_em").IsRequired();

        }
    }
}
