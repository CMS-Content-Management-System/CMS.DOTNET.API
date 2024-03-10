using Blog.Dominio.Noticias;

namespace Blog.Dominio.Categorias.Validadores
{
    public class ValidadorCategoria : IValidadorCategoria
    {
        private readonly IRepCategoria _repCategoria;
        private readonly IRepNoticia _repNoticia;

        public ValidadorCategoria(IRepCategoria repCategoria, 
            IRepNoticia repNoticia)
        {
            _repCategoria = repCategoria;
            _repNoticia = repNoticia;
        }

        public void ValidarSePodeRemover(Categoria categoria)
        {
            if (_repNoticia.ExisteNoticiaDaCategoria(categoria))
                throw new Exception($"A categoria '{categoria.Descricao}' não pode ser removida, existem notícias vinculadas a essa categoria.");
        }

        public void ValidarSePodeInativar(Categoria categoria)
        {
            if (_repNoticia.ExisteNoticiaDaCategoria(categoria))
                throw new Exception($"A categoria '{categoria.Descricao}' não pode ser inativada, existem notícias vinculadas a essa categoria.");
        }
    }
}
