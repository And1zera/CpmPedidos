using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository
{
    public class ComboMap : BaseDomainMap<Combo>
    {
        ComboMap() : base("tb_combo") { }

        public override void Configure(EntityTypeBuilder<Combo> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Preco).HasColumnName("preco").HasPrecision(17, 2).IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("ativo").IsRequired();

            // Associação 1:N (um para muitos) => Definimos o IdImagem como FK em Combo
            builder.Property(x => x.IdImagem).HasColumnName("id_imagem").IsRequired();
            // Tipo : Direcional (Apenas uma entidade vai ter a referencia) => Aqui a entidade de Combo possui uma Imagem mas a Imagem não possui uma lista de Combos
            builder.HasOne(x => x.Imagem).WithMany().HasForeignKey(x => x.IdImagem);
        }
    }
}
