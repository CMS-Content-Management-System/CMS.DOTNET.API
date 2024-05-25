namespace ApiBlog.Dominio.Usuarios.Validadores
{
    public interface IValidadorUsuario
    {
        void ValidarAlteracaoDados(Usuario usuario);
        void ValidarSePodeInativar(Usuario usuario);
        void ValidarSePodeInserir(Usuario usuario);
        void ValidarSePodeRemover(Usuario usuario);
    }
}
