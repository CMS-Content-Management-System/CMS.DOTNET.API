using ApiBlog.Dominio.Bases;
using ApiBlog.Dominio.Categorias.View;

namespace ApiBlog.Dominio.Categorias
{
    public interface IRepCategoria : IRep<Categoria>
    {
        void Add(Categoria pais);
        Task<IEnumerable<Categoria>> Get();
        Task<Categoria> Get(Guid id);
        Task Delete(Guid id);
        Task<bool> Save();
        Task<IEnumerable<CategoriaView>> GetView();
        Task<CategoriaView> GetView(Guid id);
    }
}
