using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Blog.Dominio.Noticias;

namespace Blog.Repositorio.Config.Ef
{
    public class NoticiaConfig : IEntityTypeConfiguration<Noticia>
    {
        public void Configure(EntityTypeBuilder<Noticia> builder)
        {

            builder.ToTable("NOTICIA");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IDNOTICIA")
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(x => x.Ativo)
                .HasColumnName("ATIVO")
                .IsRequired();

            builder.Property(x => x.Titulo)
                .HasColumnName("TITULO")
                .HasMaxLength(200);;

            builder.Property(x => x.Conteudo)
                .HasColumnName("CONTEUDO");
                //.HasColumnType("text");

            builder.Property(x => x.Imagem)
                .HasColumnName("IMAGEM");

            builder.Property(x => x.Prioridade)
                .HasColumnName("PRIORIDADE")
                .IsRequired();

            builder.Property(x => x.DataCriacao)
                .HasColumnName("DATACRIACAO")
                .IsRequired();

            builder.Property(x => x.CodigoAutor)
                .HasColumnName("IDAUTOR")
                .IsRequired();

            builder.Property(x => x.CodigoCategoria)
                .HasColumnName("IDCATEGORIA")
                .IsRequired();

            //

            builder.HasOne(x => x.Autor)
                .WithMany()
                .HasForeignKey(x => x.CodigoAutor)
                .IsRequired();

            builder.HasOne(x => x.Categoria)
                .WithMany()
                .HasForeignKey(x => x.CodigoCategoria)
                .IsRequired();
        }
    }
}