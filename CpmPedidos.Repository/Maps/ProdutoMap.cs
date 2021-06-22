using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository
{
    public class ProdutoMap : BaseDomainMap<Produto>
    {
        public ProdutoMap() : base("tb_produto") { }

        public override void Configure(EntityTypeBuilder<Produto> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Codigo).HasColumnName("codigo").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Descricao).HasColumnName("descricao").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Preco).HasColumnName("preco").HasPrecision(17, 2).IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("ativo").IsRequired();

            // Associação 1:N (um para muitos) => Definimos o IdCategoria como FK em Produto
            builder.Property(x => x.IdCategoria).HasColumnName("id_categoria").IsRequired();
            // Tipo : Bidirecional (As Duas entidades irão ter associações) => Aqui a entidade de Produto possui um Categoria e a Categoria possui uma lista de Produto
            builder.HasOne(x => x.Categoria).WithMany(x => x.Produtos).HasForeignKey(x => x.IdCategoria);


            builder
                .HasMany(x => x.Imagens)
                .WithMany(x => x.Produtos)
                .UsingEntity<ImagemProduto>(
                    x => x.HasOne(f => f.Imagem).WithMany().HasForeignKey(f => f.IdImagem),
                    x => x.HasOne(f => f.Produto).WithMany().HasForeignKey(f => f.IdProduto),
                    x =>
                    {
                        x.ToTable("tb_imagem_produto");

                        x.HasKey(x => new { x.IdImagem, x.IdProduto });

                        x.Property(x => x.IdProduto).HasColumnName("id_produto").IsRequired();
                        x.Property(x => x.IdImagem).HasColumnName("id_imagem").IsRequired();

                    }

                );
        }
    }
}

