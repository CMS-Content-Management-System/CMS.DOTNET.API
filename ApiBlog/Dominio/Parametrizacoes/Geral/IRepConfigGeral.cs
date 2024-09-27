using ApiBlog.Dominio.Bases;
using ApiBlog.Dominio.Parametrizacoes.Geral.View;

namespace ApiBlog.Dominio.Parametrizacoes.Geral
{
    public interface IRepConfigGeral : IRep<ConfigGeral>
    {
        Task<ConfigGeral> Get();
        Task<ConfigGeralView> GetView();
        Task<bool> Save();
    }
}
