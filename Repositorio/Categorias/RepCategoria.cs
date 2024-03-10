using Blog.Dominio.Categorias;
using Blog.Repositorio.Bases;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repositorio.Categorias
{
    public class RepCategoria : Rep<Categoria>, IRepCategoria
    {
        public RepCategoria(ApplicationContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Categoria>> Get()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Categoria> Get(Guid id)
        {
            var categoria = await DbSet.FirstOrDefaultAsync(p => p.Id == id);

            if (categoria == null)
                return null;

            return categoria;
        }

        public void Add(Categoria categoria)
        {
            DbSet.Add(categoria);
        }

        public async Task Delete(Guid id)
        {
            var categoria = await Get(id);

            if (categoria != null)
                DbSet.Remove(categoria);
        }

        public async Task<bool> Save()
        {
            return await Db.SaveChangesAsync() > 0;
        }
    }
}
