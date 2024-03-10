using Blog.Dominio.Bases;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repositorio.Bases
{
    public abstract class Rep<TEntidade> : IRep<TEntidade> where TEntidade : Identificador
    {
        protected readonly DbContext Db;
        protected readonly DbSet<TEntidade> DbSet;

        public Rep(ApplicationContext contexto)
        {
            Db = contexto;
            DbSet = Db.Set<TEntidade>();
        }
    }
}
