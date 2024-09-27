using ApiBlog.Dominio.Parametrizacoes.Geral;
using ApiBlog.Dominio.Parametrizacoes.Geral.View;
using ApiBlog.Repositorio.Bases;
using Microsoft.EntityFrameworkCore;

namespace ApiBlog.Repositorio.Parametrizacoes.Geral
{
    public class RepConfigGeral : Rep<ConfigGeral>, IRepConfigGeral
    {
        public RepConfigGeral(ApplicationContext contexto) 
            : base(contexto)
        {
        }

        public async Task<ConfigGeralView> GetView()
        {
            var configGeral = await DbSet.Select(x => new ConfigGeralView
            {
                Id = x.Id,
                NomeSite = x.NomeSite,
                ImagemSite = x.ImagemSite,
                Nome = x.Nome,
                Fone = x.Fone,
                Email = x.Email,
                Endereco = x.Endereco,
                Instagram = x.Instagram,
                Facebook = x.Facebook
            }).FirstOrDefaultAsync();

            return configGeral;
        }

        public async Task<ConfigGeral> Get()
        {
            var config = await DbSet.FirstOrDefaultAsync();

            if (config == null)
                return null;

            return config;
        }

        public void Add(ConfigGeral config)
        {
            DbSet.Add(config);
        }

        public async Task<bool> Save()
        {
            return await Db.SaveChangesAsync() > 0;
        }
    }
}
