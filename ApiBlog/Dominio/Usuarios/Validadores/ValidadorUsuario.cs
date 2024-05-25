using ApiBlog.Dominio.Noticias;

namespace ApiBlog.Dominio.Usuarios.Validadores
{
    public class ValidadorUsuario : IValidadorUsuario
    {
        private readonly IRepUsuario _repUsuario;
        private readonly IRepNoticia _repNoticia;

        public ValidadorUsuario(IRepUsuario repUsuario,
            IRepNoticia repNoticia)
        {
            _repUsuario = repUsuario;
            _repNoticia = repNoticia;
        }

        public void ValidarSePodeInserir(Usuario usuario)
        {
            if (_repUsuario.VerificarSeEmailJaCadastrado(usuario.Email))
                throw new Exception($"O e-mail '{usuario.Email}' já está cadastrado no sistema!");
        }
        public void ValidarAlteracaoDados(Usuario usuario)
        {
            if (_repUsuario.VerificarSeEmailJaCadastradoParaOutroUsuario(usuario))
                throw new Exception($"O e-mail '{usuario.Email}' já está cadastrado no sistema!");
        }

        public void ValidarSePodeRemover(Usuario usuario)
        {
            if (_repNoticia.ExisteNoticiaDoAutor(usuario))
                throw new Exception($"O usuário '{usuario.Nome}' não pode ser removido, existem notícias vinculadas a ele como autor.");

            if (!_repUsuario.ExistemOutrosUsuarios(usuario))
                throw new Exception($"O usuário '{usuario.Nome}' é o único usuário cadastrado e não pode ser removido.");
        }

        public void ValidarSePodeInativar(Usuario usuario)
        {
            if (_repNoticia.ExisteNoticiaDoAutor(usuario))
                throw new Exception($"O usuário '{usuario.Nome}' não pode ser inativado, existem notícias vinculadas a ele como autor.");
        }
    }
}
