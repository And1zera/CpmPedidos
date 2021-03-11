using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository
{
    public class CidadeMap : BaseDomainMap<Cidade>
    {
        CidadeMap() : base("tb_cidade") {}

        public override void Configure(EntityTypeBuilder<Cidade> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(100).IsRequired();
            builder.Property(x => x.UF).HasColumnName("uf").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("ativo").IsRequired();
        }
    }
}
