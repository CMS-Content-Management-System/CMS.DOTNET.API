using Blog.Dominio.Categorias;
using Blog.Dominio.Noticias;
using Blog.Dominio.Usuarios;
using Blog.Repositorio.Bases;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repositorio.Noticias
{
    public class RepNoticia : Rep<Noticia>, IRepNoticia
    {
        public RepNoticia(ApplicationContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Noticia>> Get()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Noticia> Get(Guid id)
        {
            var noticia = await DbSet.FirstOrDefaultAsync(p => p.Id == id);

            if (noticia == null)
                return null;

            return noticia;
        }

        public void Add(Noticia noticia)
        {
            DbSet.Add(noticia);
        }

        public async Task Delete(Guid id)
        {
            var noticia = await Get(id);

            if (noticia != null)
                DbSet.Remove(noticia);
        }

        public async Task<bool> Save()
        {
            return await Db.SaveChangesAsync() > 0;
        }

        public bool ExisteNoticiaDaCategoria(Categoria categoria)
        {
            return DbSet.Any(p => p.CodigoCategoria == categoria.Id);
        }

        public bool ExisteNoticiaDoAutor(Usuario autor)
        {
            return DbSet.Any(p => p.CodigoAutor == autor.Id);
        }
    }
}
