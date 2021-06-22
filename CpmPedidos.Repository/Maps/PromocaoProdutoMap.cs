using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository
{
    public class PromocaoProdutoMap : BaseDomainMap<PromocaoProduto>
    {
        public PromocaoProdutoMap() : base("tb_promocao_produto") {}

        public override void Configure(EntityTypeBuilder<PromocaoProduto> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Preco).HasColumnName("preco").HasPrecision(17, 2).IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("ativo").IsRequired();

            // Associação 1:N (um para muitos) => Definimos o IdImagem como FK em PromocaoProduto
            builder.Property(x => x.IdImagem).HasColumnName("id_imagem").IsRequired();
            // Tipo : Direcional (Apenas uma entidade vai ter a referencia) => Aqui a entidade de PromocaoProduto possui uma Imagem mas a Imagem não possui uma lista de PromocaoProduto
            builder.HasOne(x => x.Imagem).WithMany().HasForeignKey(x => x.IdImagem);

            // Associação 1:N (um para muitos) => Definimos o IdProduto como FK em PromocaoProduto
            builder.Property(x => x.IdProduto).HasColumnName("id_produto").IsRequired();
            // Tipo : Bidirecional (As Duas entidades irão ter associações) => Aqui a entidade de PromocaoProduto possui um Produto e a Produto possui uma lista de PromocaoProduto
            builder.HasOne(x => x.Produto).WithMany(x => x.Promocoes).HasForeignKey(x => x.IdProduto);
        }
    }
}
