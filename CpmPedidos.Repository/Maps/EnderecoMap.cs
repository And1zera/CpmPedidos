using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository
{
    public class EnderecoMap : BaseDomainMap<Endereco>
    {
        EnderecoMap() : base("tb_endereco") { }

        public override void Configure(EntityTypeBuilder<Endereco> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Tipo).HasColumnName("tipo").IsRequired();
            builder.Property(x => x.Logradouro).HasColumnName("logradouro").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Bairro).HasColumnName("bairro").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Numero).HasColumnName("numero").HasMaxLength(10).IsRequired();
            builder.Property(x => x.Complemento).HasColumnName("complemento").HasMaxLength(50);
            builder.Property(x => x.CEP).HasColumnName("cep").HasMaxLength(8);


            // Associação 1:1 (um para um) => Definindo a tabela de Cliente que vai conter um Endereco
            builder.HasOne(x => x.Cliente).WithOne(x => x.Endereco).HasForeignKey<Cliente>(x => x.IdEndereco);

            // Associação 1:N (um para muitos) => Definimos o IdCidade como FK em Endereco
            builder.Property(x => x.IdCidade).HasColumnName("id_cidade").IsRequired();
            // Tipo : Direcional (Apenas uma entidade vai ter a referencia) => Aqui a entidade de Endereço possui uma cidade mas a cidade não possui uma lista de Endereço
            builder.HasOne(x => x.Cidade).WithMany().HasForeignKey(x => x.IdCidade);

        }
    }
}
