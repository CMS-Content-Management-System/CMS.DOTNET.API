using ApiBlog.Dominio.Bases;
using ApiBlog.Dominio.Usuarios;
using ApiBlog.Dominio.Usuarios.View;
using ApiBlog.Repositorio.Bases;
using Microsoft.EntityFrameworkCore;

namespace ApiBlog.Repositorio.Usuarios
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

        public async Task<IEnumerable<UsuarioView>> GetView(QueryParams? queryParams = null)
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
                .Select(x => new UsuarioView
                {
                    Id = x.Id,
                    Ativo = x.Ativo,
                    Nome = x.Nome,
                    SobreNome = x.SobreNome,
                    Email = x.Email,
                    Admin = x.Admin,
                    FotoPerfil = x.FotoPerfil
                }).OrderBy(x => x.Nome)
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

        public async Task<Usuario> RecuperarUsuarioLogin(string email, string senha)
        {
            var senhaEncriptada = Usuario.EncriptarSenha(senha);

            return await DbSet.FirstOrDefaultAsync(x => x.Email == email.Trim() && x.Senha == senhaEncriptada);
        }

        public async Task<Usuario> Get(Guid id)
        {
            return await DbSet.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<UsuarioView> GetView(Guid id)
        {
            var usuario = await DbSet.Select(x => new UsuarioView
            {
                Id = x.Id,
                Ativo = x.Ativo,
                Nome = x.Nome,
                SobreNome = x.SobreNome,
                Email = x.Email,
                Admin = x.Admin,
                FotoPerfil = x.FotoPerfil
            }).FirstOrDefaultAsync(p => p.Id == id);

            return usuario;
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
