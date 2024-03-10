using Blog.Dominio.Usuarios;
using Blog.Repositorio.Bases;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repositorio.Usuarios
{
    public class RepUsuario : Rep<Usuario>, IRepUsuario
    {
        public RepUsuario(ApplicationContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Usuario>> Get()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Usuario> Get(Guid id)
        {
            var categoria = await DbSet.FirstOrDefaultAsync(p => p.Id == id);

            if (categoria == null)
                return null;

            return categoria;
        }

        public void Add(Usuario usuario)
        {
            DbSet.Add(usuario);
        }

        public async Task Delete(Guid id)
        {
            var usuario = await Get(id);

            if (usuario != null)
                DbSet.Remove(usuario);
        }

        public async Task<bool> Save()
        {
            return await Db.SaveChangesAsync() > 0;
        }

        public bool VerificarSeEmailJaCadastrado(string email)
        {
            return DbSet.Where(p => p.Email.ToLower() == email.ToLower()).Any();
        }

        public bool VerificarSeEmailJaCadastradoParaOutroUsuario(Usuario usuario)
        {
            return DbSet.Where(p => p.Email.ToLower() == usuario.Email.ToLower() && p.Id != usuario.Id).Any();
        }

        public bool ExistemOutrosUsuarios(Usuario usuario)
        {
            return DbSet.Any(p => p.Id != usuario.Id);
        }
    }
}
