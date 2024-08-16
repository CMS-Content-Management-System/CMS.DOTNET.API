using ApiBlog.Dominio.Bases;
using ApiBlog.Dominio.Categorias;
using ApiBlog.Dominio.Usuarios;

namespace ApiBlog.Dominio.Noticias
{
    public class Noticia : Identificador
    {
        public Noticia()
        {
        }

        public Noticia(string titulo, string subTitulo, string conteudo, string imagem, int prioridade, Usuario autor, Categoria categoria)
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
            Ativo = true;
            Prioridade = prioridade;
            AlterarTitulo(titulo);
            AlterarSubTitulo(subTitulo);
            AlterarConteudo(conteudo);
            Imagem = imagem;
            CodigoAutor = autor.Id;
            Autor = autor;
            CodigoCategoria = categoria.Id;
            Categoria = categoria;
        }

        public bool Ativo { get; private set; }
        public string Titulo { get; private set; }
        public string SubTitulo { get; private set; }
        public string Conteudo { get; private set; }
        public string Imagem { get; private set; }
        public int Prioridade { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public Guid CodigoAutor { get; private set; }
        public Guid CodigoCategoria { get; private set; }

        //
        public Usuario Autor { get; private set; }
        public Categoria Categoria { get; private set; }

        public void Ativar() => Ativo = true;
        public void Inativar() => Ativo = false;


        public void AlterarTitulo(string titulo)
        {
            if (titulo.Trim() == "")
                throw new Exception("Informe um título para notícia!");

            Titulo = titulo;
        }

        public void AlterarConteudo(string conteudo)
        {
            if (conteudo.Trim() == "")
                throw new Exception("Informe um conteúdo para notícia!");

            Conteudo = conteudo;
        }

        public void AlterarSubTitulo(string subTitulo) {
            if (subTitulo.Trim() == "")
                throw new Exception("Informe um subtítulo para notícia!");

            SubTitulo = subTitulo;
        }

        public void AlterarDados(string titulo, string subTitulo, string conteudo, string imagem, int prioridade, Usuario autor, Categoria categoria)
        {
            AlterarTitulo(titulo);
            AlterarSubTitulo(subTitulo);
            AlterarConteudo(conteudo);
            Prioridade = prioridade;
            Imagem = imagem;
            CodigoAutor = autor.Id;
            Autor = autor;
            CodigoCategoria = categoria.Id;
            Categoria = categoria;
        }
    }
}
