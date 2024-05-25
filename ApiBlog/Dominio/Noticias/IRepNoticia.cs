using ApiBlog.Dominio.Bases;
using ApiBlog.Dominio.Categorias;
using ApiBlog.Dominio.Noticias.View;
using ApiBlog.Dominio.Usuarios;

namespace ApiBlog.Dominio.Noticias
{
    public interface IRepNoticia : IRep<Noticia>
    {
        void Add(Noticia pais);
        Task<IEnumerable<Noticia>> Get();
        Task<Noticia> Get(Guid id);
        Task Delete(Guid id);
        Task<bool> Save();
        bool ExisteNoticiaDaCategoria(Categoria categoria);
        bool ExisteNoticiaDoAutor(Usuario autor);
        Task<IEnumerable<NoticiaView>> GetView();
        Task<NoticiaView> GetView(Guid id);
    }
}
