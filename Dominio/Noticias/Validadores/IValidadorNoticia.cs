namespace Blog.Dominio.Noticias.Validadores
{
    public interface IValidadorNoticia
    {
        void ValidarAlteracao(Noticia noticia);
        void ValidarSePodeInserir(Noticia noticia);
    }
}
