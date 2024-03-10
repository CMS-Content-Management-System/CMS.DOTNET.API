using Blog.Dominio.Bases;

namespace Blog.Dominio.Usuarios
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
    }
}
