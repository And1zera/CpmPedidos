using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository
{
    public class PedidoMap : BaseDomainMap<Pedido>
    {
        PedidoMap() : base("tb_pedido") {}

        public override void Configure(EntityTypeBuilder<Pedido> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Numero).HasColumnName("numero").HasMaxLength(10).IsRequired();
            builder.Property(x => x.ValorTotal).HasColumnName("valor_total").HasPrecision(17, 2).IsRequired();
            builder.Property(x => x.Entrega).HasColumnName("entrega").IsRequired();

            // Associação 1:N (um para muitos) => Definimos o IdCliente como FK em Pedido
            builder.Property(x => x.IdCliente).HasColumnName("id_cliente").IsRequired();
            // Tipo : Bidirecional (As Duas entidades irão ter associações) => Aqui a entidade de Pedido possui uma Cliente e a Cliente possui uma lista de Pedido
            builder.HasOne(x => x.Cliente).WithMany(x => x.Pedidos).HasForeignKey(x => x.IdCliente);
        }
    }
}
