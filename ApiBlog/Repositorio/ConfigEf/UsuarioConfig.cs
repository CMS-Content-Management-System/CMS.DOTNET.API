using ApiBlog.Dominio.Usuarios;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiBlog.Repositorio.ConfigEf
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            builder.ToTable("USUARIO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IDUSUARIO")
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(x => x.Ativo)
                .HasColumnName("ATIVO")
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.SobreNome)
                .HasColumnName("SOBRENOME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Senha)
                .HasColumnName("SENHA")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.FotoPerfil)
                .HasColumnName("FOTOPERFIL")
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(x => x.Admin)
                .HasColumnName("ADMIN")
                .IsRequired();

            builder.Property(x => x.DataCriacao)
                .HasColumnName("DATACRIACAO")
                .IsRequired();
        }
    }
}
