using ApiBlog.Repositorio.ConfigEf;
using Microsoft.EntityFrameworkCore;

namespace ApiBlog.Repositorio
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);

            //MultiBancoRepositorioBase.OnModelCreating(this);
            //DbContextHelper.ConfigurarCasasDecimais(modelBuilder);
        }

        public virtual void ModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new CategoriaConfig())
                .ApplyConfiguration(new UsuarioConfig())
                .ApplyConfiguration(new NoticiaConfig())
            ;
        }
    }
}
