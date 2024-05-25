using ApiBlog.Dominio.Categorias;
using ApiBlog.Dominio.Categorias.View;
using ApiBlog.Repositorio.Bases;
using Microsoft.EntityFrameworkCore;

namespace ApiBlog.Repositorio.Categorias
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

        public async Task<IEnumerable<CategoriaView>> GetView()
        {
            return await DbSet.Select(x => new CategoriaView
            {
                Id = x.Id,
                Ativo = x.Ativo,
                Descricao = x.Descricao
            }).ToListAsync();
        }

        public async Task<Categoria> Get(Guid id)
        {
            var categoria = await DbSet.FirstOrDefaultAsync(p => p.Id == id);

            if (categoria == null)
                return null;

            return categoria;
        }

        public async Task<CategoriaView> GetView(Guid id)
        {
            var categoria = await DbSet.Select(x => new CategoriaView
            {
                Id = x.Id,
                Ativo = x.Ativo,
                Descricao = x.Descricao
            }).FirstOrDefaultAsync(p => p.Id == id);

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
