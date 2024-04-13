using Blog.Dominio.Bases;
using Blog.Dominio.Categorias;
using Blog.Dominio.Usuarios;

namespace Blog.Dominio.Noticias
{
    public interface IRepNoticia : IRep<Noticia>
    {
        void Add(Noticia pais);
        Task<IEnumerable<Noticia>> Get();
        Task<Noticia> Get(Guid id);
        Task<IEnumerable<Noticia>> GetIncludingCategoria();
        Task Delete(Guid id);
        Task<bool> Save();
        bool ExisteNoticiaDaCategoria(Categoria categoria);
        bool ExisteNoticiaDoAutor(Usuario autor);
    }
}
