using ApiBlog.Dominio.Bases;
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

        public async Task<IEnumerable<CategoriaView>> GetView(QueryParams queryParams = null)
        {
            if (queryParams == null)
            {
                queryParams = new QueryParams
                {
                    Pagina = 1,
                    Limite = 10
                };
            }

            if (queryParams.Pagina < 1)
                queryParams.Pagina = 1;

            if (queryParams.Limite < 1)
                queryParams.Limite = 10;

            if (queryParams.Limite > 10)
                queryParams.Limite = 10;

            return await DbSet.Select(x => new CategoriaView
            {
                Id = x.Id,
                Ativo = x.Ativo,
                Descricao = x.Descricao
            }).Skip((queryParams.Pagina - 1) * queryParams.Limite)
              .Take(queryParams.Limite)
              .ToListAsync();
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
