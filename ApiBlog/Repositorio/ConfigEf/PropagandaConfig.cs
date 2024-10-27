using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ApiBlog.Dominio.Propagandas;

namespace ApiBlog.Repositorio.ConfigEf
{
    public class PropagandaConfig : IEntityTypeConfiguration<Propaganda>
    {
        public void Configure(EntityTypeBuilder<Propaganda> builder)
        {

            builder.ToTable("PROPAGANDA");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IDPROPAGANDA")
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(x => x.Ativo)
                .HasColumnName("ATIVO")
                .IsRequired();

            builder.Property(x => x.Titulo)
                .HasColumnName("TITULO")
                .HasMaxLength(200); ;

            builder.Property(x => x.Imagem)
                .HasColumnName("IMAGEM");

            builder.Property(x => x.Link)
                .HasColumnName("LINK");

            builder.Property(x => x.Prioridade)
                .HasColumnName("PRIORIDADE")
                .IsRequired();
        }
    }
}
