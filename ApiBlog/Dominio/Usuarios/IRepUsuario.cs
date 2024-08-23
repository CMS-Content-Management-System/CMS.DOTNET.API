using ApiBlog.Dominio.Bases;
using ApiBlog.Dominio.Usuarios.View;

namespace ApiBlog.Dominio.Usuarios
{
    public interface IRepUsuario : IRep<Usuario>
    {
        void Add(Usuario Usuario);
        Task<IEnumerable<Usuario>> Get();
        Task<Usuario> Get(Guid id);
        Task Delete(Guid id);
        Task<bool> Save();
        bool VerificarSeEmailJaCadastrado(string email);
        bool VerificarSeEmailJaCadastradoParaOutroUsuario(Usuario usuario);
        bool ExistemOutrosUsuarios(Usuario usuario);
        Task<IEnumerable<UsuarioView>> GetView(QueryParams queryParams = null);
        Task<UsuarioView> GetView(Guid id);
        Task<Usuario> RecuperarUsuarioLogin(string email, string senha);
    }
}
