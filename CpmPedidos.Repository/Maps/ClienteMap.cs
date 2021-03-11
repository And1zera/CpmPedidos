using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository
{
    public class ClienteMap : BaseDomainMap<Cliente>
    {
        ClienteMap() : base("tb_cliente") { }

        public override void Configure(EntityTypeBuilder<Cliente> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(100).IsRequired();
            builder.Property(x => x.CPF).HasColumnName("cpf").HasMaxLength(14).IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("ativo").IsRequired();

            builder.Property(x => x.IdEndereco).HasColumnName("id_endereco").IsRequired();
        }
    }
}
