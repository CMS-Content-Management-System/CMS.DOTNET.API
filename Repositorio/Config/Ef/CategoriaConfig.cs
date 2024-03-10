using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Blog.Dominio.Categorias;

namespace Blog.Repositorio.Config.Ef
{
    public class CategoriaConfig : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {

            builder.ToTable("CATEGORIA");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IDCATEGORIA")
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(x => x.Ativo)
                .HasColumnName("ATIVO")
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.DataCriacao)
                .HasColumnName("DATACRIACAO")
                .IsRequired();
        }
    }
}
