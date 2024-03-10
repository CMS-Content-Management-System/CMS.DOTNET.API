namespace Blog.Dominio.Noticias.Validadores
{
    public class ValidadorNoticia : IValidadorNoticia
    {
        public void ValidarSePodeInserir(Noticia noticia)
        {
            if (!noticia.Autor.Ativo)
                throw new Exception($"O autor '{noticia.Autor.Nome}' está inativo.");

            if (!noticia.Categoria.Ativo)
                throw new Exception($"A categoria '{noticia.Categoria.Descricao}' está inativa.");
        }

        public void ValidarAlteracao(Noticia noticia)
        {
            if (!noticia.Autor.Ativo)
                throw new Exception($"O autor '{noticia.Autor.Nome}' está inativo.");

            if (!noticia.Categoria.Ativo)
                throw new Exception($"A categoria '{noticia.Categoria.Descricao}' está inativa.");
        }
    }
}
