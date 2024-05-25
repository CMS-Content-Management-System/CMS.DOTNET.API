using ApiBlog.Dominio.Usuarios;

namespace ApiBlog.Dominio.Geral
{
    public interface ITokenService
    {
        string Gerar(Usuario usuario);
    }
}
