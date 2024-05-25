using ApiBlog.Dominio.Categorias;
using ApiBlog.Dominio.Categorias.View;
using ApiBlog.Dominio.Noticias;
using ApiBlog.Dominio.Noticias.View;
using ApiBlog.Dominio.Usuarios;
using ApiBlog.Dominio.Usuarios.View;
using ApiBlog.Repositorio.Bases;
using Microsoft.EntityFrameworkCore;

namespace ApiBlog.Repositorio.Noticias
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

        public async Task<IEnumerable<NoticiaView>> GetView()
        {
            return await DbSet.Select(x => new NoticiaView
            {
                Id = x.Id,
                Ativo = x.Ativo,
                Titulo = x.Titulo,
                DataCriacao = x.DataCriacao,
                Conteudo = x.Conteudo,
                Imagem = x.Imagem,
                CodigoAutor = x.CodigoAutor,
                CodigoCategoria = x.CodigoCategoria,
                Autor = new UsuarioView
                {
                    Id = x.Autor.Id,
                    Ativo = x.Autor.Ativo,
                    Nome = x.Autor.Nome,
                    SobreNome = x.Autor.SobreNome,
                    Admin = x.Autor.Admin,
                    Email = x.Autor.Email,
                    FotoPerfil = x.Autor.FotoPerfil
                },
                Categoria = new CategoriaView
                {
                    Id = x.Categoria.Id,
                    Ativo = x.Categoria.Ativo,
                    Descricao = x.Categoria.Descricao
                }
            }).ToListAsync();
        }

        public async Task<Noticia> Get(Guid id)
        {
            var noticia = await DbSet.FirstOrDefaultAsync(p => p.Id == id);

            if (noticia == null)
                return null;

            return noticia;
        }

        public async Task<NoticiaView> GetView(Guid id)
        {
            var noticia = await DbSet.Select(x => new NoticiaView
            {
                Id = x.Id,
                Ativo = x.Ativo,
                Titulo = x.Titulo,
                DataCriacao = x.DataCriacao,
                Conteudo = x.Conteudo,
                Imagem = x.Imagem,
                CodigoAutor = x.CodigoAutor,
                CodigoCategoria = x.CodigoCategoria,
                Autor = new UsuarioView
                {
                    Id = x.Autor.Id,
                    Ativo = x.Autor.Ativo,
                    Nome = x.Autor.Nome,
                    SobreNome = x.Autor.SobreNome,
                    Admin = x.Autor.Admin,
                    Email = x.Autor.Email,
                    FotoPerfil = x.Autor.FotoPerfil
                },
                Categoria = new CategoriaView
                {
                    Id = x.Categoria.Id,
                    Ativo = x.Categoria.Ativo,
                    Descricao = x.Categoria.Descricao
                }
            }).FirstOrDefaultAsync(p => p.Id == id);

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
