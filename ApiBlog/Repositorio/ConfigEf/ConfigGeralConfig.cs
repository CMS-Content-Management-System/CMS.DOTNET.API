using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ApiBlog.Dominio.Parametrizacoes.Geral;

namespace ApiBlog.Repositorio.ConfigEf
{
    public class ConfigGeralConfig : IEntityTypeConfiguration<ConfigGeral>
    {
        public void Configure(EntityTypeBuilder<ConfigGeral> builder)
        {

            builder.ToTable("CONFIGGERAL");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IDCONFIGGERAL")
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(x => x.NomeSite)
                .HasColumnName("NOMESITE")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.ImagemSite)
                .HasColumnName("IMAGEMSITE");

            builder.Property(x => x.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(200);

            builder.Property(x => x.Fone)
                .HasColumnName("FONE")
                .HasMaxLength(20);

            builder.Property(x => x.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(100);

            builder.Property(x => x.Endereco)
                .HasColumnName("ENDERECO")
                .HasMaxLength(100);

            builder.Property(x => x.Instagram)
                .HasColumnName("INSTAGRAM")
                .HasMaxLength(300);

            builder.Property(x => x.Facebook)
                .HasColumnName("FACEBOOK")
                .HasMaxLength(300);
        }
    }
}
