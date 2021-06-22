using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository
{
    public class ProdutoPedidoMap : BaseDomainMap<ProdutoPedido>
    {
        public ProdutoPedidoMap() : base("tb_produto_pedido") { }

        public override void Configure(EntityTypeBuilder<ProdutoPedido> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Quantidade).HasColumnName("quantidade").HasPrecision(2).IsRequired();
            builder.Property(x => x.Preco).HasColumnName("preco").HasPrecision(17, 2).IsRequired();

            // Associação N:N (muitos para muitos) => Definimos o IdPedido como FK em ProdutoPedido
            builder.Property(x => x.IdPedido).HasColumnName("id_pedido").IsRequired();
            // Tipo : Bidirecional (As Duas entidades irão ter associações)
            builder.HasOne(x => x.Pedido).WithMany(x => x.Produtos).HasForeignKey(x => x.IdPedido);

            // Associação N:N (muitos para muitos) => Definimos o IdProduto como FK em ProdutoPedido
            builder.Property(x => x.IdProduto).HasColumnName("id_produto").IsRequired();
            // Tipo : Direcional (Apenas uma entidade vai ter a referencia)
            builder.HasOne(x => x.Produto).WithMany().HasForeignKey(x => x.IdProduto);

        }
    }
}
