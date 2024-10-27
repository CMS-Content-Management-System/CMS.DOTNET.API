using ApiBlog.Dominio.Bases;
using ApiBlog.Dominio.Propagandas.View;

namespace ApiBlog.Dominio.Propagandas
{
    public interface IRepPropaganda : IRep<Propaganda>
    {
        void Add(Propaganda propaganda);
        Task<int> Count(QueryParams? queryParams = null);
        Task Delete(Guid id);
        Task<IEnumerable<Propaganda>> Get();
        Task<Propaganda> Get(Guid id);
        Task<IEnumerable<PropagandaView>> GetView(QueryParams? queryParams = null);
        Task<PropagandaView> GetView(Guid id);
        Task<bool> Save();
    }
}
