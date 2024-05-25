using ApiBlog.Dominio.Categorias.View;
using ApiBlog.Dominio.Usuarios.View;

namespace ApiBlog.Dominio.Noticias.View
{
    public class NoticiaView
    {
        public Guid Id { get; set; }
        public bool Ativo { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public string Imagem { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid CodigoAutor { get; set; }
        public Guid CodigoCategoria { get; set; }

        //
        public UsuarioView Autor { get; set; }
        public CategoriaView Categoria { get; set; }
    }
}
