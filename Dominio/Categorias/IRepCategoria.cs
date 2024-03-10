using Blog.Dominio.Bases;

namespace Blog.Dominio.Categorias
{
    public interface IRepCategoria : IRep<Categoria>
    {
        void Add(Categoria pais);
        Task<IEnumerable<Categoria>> Get();
        Task<Categoria> Get(Guid id);
        Task Delete(Guid id);
        Task<bool> Save();
    }
}
