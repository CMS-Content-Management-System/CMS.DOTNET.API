namespace Blog.Dominio.Categorias.Validadores
{
    public interface IValidadorCategoria
    {
        void ValidarSePodeInativar(Categoria categoria);
        void ValidarSePodeRemover(Categoria categoria);
    }
}
