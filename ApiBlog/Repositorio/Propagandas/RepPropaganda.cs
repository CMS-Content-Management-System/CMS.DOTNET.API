using ApiBlog.Dominio.Bases;
using ApiBlog.Repositorio.Bases;
using Microsoft.EntityFrameworkCore;
using ApiBlog.Dominio.Propagandas;
using ApiBlog.Dominio.Propagandas.View;

namespace ApiBlog.Repositorio.Propagandas
{
    public class RepPropaganda : Rep<Propaganda>, IRepPropaganda
    {
        public RepPropaganda(ApplicationContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Propaganda>> Get()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<PropagandaView>> GetView(QueryParams? queryParams = null)
        {
            if (queryParams == null)
                queryParams = new QueryParams();

            if (queryParams.Pagina < 1)
                queryParams.Pagina = 1;

            if (queryParams.Limite < 1)
                queryParams.Limite = 10;

            if (queryParams.Limite > 10)
                queryParams.Limite = 10;

            return await DbSet.Where(x => !queryParams.Ativo.HasValue || x.Ativo == queryParams.Ativo.Value)
                .Select(x => new PropagandaView
                {
                    Id = x.Id,
                    Ativo = x.Ativo,
                    Titulo = x.Titulo,
                    Imagem = x.Imagem,
                    Link = x.Link,
                    Prioridade = x.Prioridade
                }).OrderByDescending(x => x.Prioridade)
                  .Skip((queryParams.Pagina - 1) * queryParams.Limite)
                  .Take(queryParams.Limite)
                  .ToListAsync();
        }

        public async Task<int> Count(QueryParams? queryParams = null)
        {
            if (queryParams == null)
                queryParams = new QueryParams();

            return await DbSet.CountAsync(x => !queryParams.Ativo.HasValue || x.Ativo == queryParams.Ativo.Value);
        }

        public async Task<Propaganda> Get(Guid id)
        {
            var propaganda = await DbSet.FirstOrDefaultAsync(p => p.Id == id);

            if (propaganda == null)
                return null;

            return propaganda;
        }

        public async Task<PropagandaView> GetView(Guid id)
        {
            var propaganda = await DbSet.Select(x => new PropagandaView
            {
                Id = x.Id,
                Ativo = x.Ativo,
                Titulo = x.Titulo,
                Imagem = x.Imagem,
                Link = x.Link,
                Prioridade = x.Prioridade
            }).FirstOrDefaultAsync(p => p.Id == id);

            return propaganda;
        }

        public void Add(Propaganda propaganda)
        {
            DbSet.Add(propaganda);
        }

        public async Task Delete(Guid id)
        {
            var propaganda = await Get(id);

            if (propaganda != null)
                DbSet.Remove(propaganda);
        }

        public async Task<bool> Save()
        {
            return await Db.SaveChangesAsync() > 0;
        }
    }
}
