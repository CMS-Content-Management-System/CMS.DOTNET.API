using ApiBlog.Dominio.Categorias;
using ApiBlog.Dominio.Noticias.Validadores;
using ApiBlog.Dominio.Noticias;
using ApiBlog.Dominio.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ApiBlog.Controllers.Admin
{
    [ApiController]
    [Route("api/admin-noticia")]
    public class AdminNoticiaController : ControllerBase
    {
        #region CTor
        private readonly IRepNoticia _rep;
        private readonly IRepCategoria _repCategoria;
        private readonly IRepUsuario _repUsuario;
        private readonly IValidadorNoticia _validador;

        public AdminNoticiaController(IRepNoticia rep,
            IRepCategoria repCategoria,
            IRepUsuario repUsuario,
            IValidadorNoticia validador)
        {
            _rep = rep;
            _repCategoria = repCategoria;
            _repUsuario = repUsuario;
            _validador = validador;
        }
        #endregion

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> InserirNoticia(NoticiaDto dto)
        {
            try
            {
                var categoria = await _repCategoria.Get(dto.CodigoCategoria);
                if (categoria == null)
                    return BadRequest($"Categoria de código '{dto.CodigoCategoria}' não existe!");

                var idUsuario = User.Claims.FirstOrDefault(x => x.Type == "IdUsuario")?.Value;

                if (idUsuario == null)
                    return BadRequest();

                var guidUsuario = Guid.Parse(idUsuario);

                var autor = await _repUsuario.Get(guidUsuario);
                if (autor == null)
                    return BadRequest($"Autor de código '{guidUsuario}' não existe!");

                var noticia = new Noticia(dto.Titulo, dto.Conteudo, dto.Imagem, dto.Prioridade, autor, categoria);

                _validador.ValidarSePodeInserir(noticia);

                _rep.Add(noticia);

                await _rep.Save();

                return Ok(noticia);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarNoticia(Guid id, NoticiaDto dto)
        {
            try
            {
                var noticia = await _rep.Get(id);

                if (noticia == null)
                    return BadRequest($"Noticia de código '{id}' não existe!");

                var categoria = await _repCategoria.Get(dto.CodigoCategoria);
                if (categoria == null)
                    return BadRequest($"Categoria de código '{dto.CodigoCategoria}' não existe!");

                var idUsuario = User.Claims.FirstOrDefault(x => x.Type == "IdUsuario")?.Value;
                if (idUsuario == null)
                    return BadRequest();

                var guidUsuario = Guid.Parse(idUsuario);
                
                var autor = await _repUsuario.Get(guidUsuario);
                if (autor == null)
                    return BadRequest($"Autor de código '{guidUsuario}' não existe!");

                noticia.AlterarDados(dto.Titulo, dto.Conteudo, dto.Imagem, dto.Prioridade, autor, categoria);

                _validador.ValidarAlteracao(noticia);

                await _rep.Save();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverNoticia(Guid id)
        {
            try
            {
                var noticia = await _rep.Get(id);

                if (noticia == null)
                    return BadRequest($"Noticia de código '{id}' não existe!");

                await _rep.Delete(id);
                await _rep.Save();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpPut("{id}/ativar")]
        public async Task<IActionResult> Ativar(Guid id)
        {
            try
            {
                var noticia = await _rep.Get(id);

                if (noticia == null)
                    return BadRequest($"Noticia de código '{id}' não existe!");

                if (noticia.Ativo)
                    return BadRequest($"Noticia '{noticia.Titulo}' já está ativa!");

                noticia.Ativar();

                await _rep.Save();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpPut("{id}/inativar")]
        public async Task<IActionResult> Inativar(Guid id)
        {
            try
            {
                var noticia = await _rep.Get(id);

                if (noticia == null)
                    return BadRequest($"Noticia de código '{id}' não existe!");

                if (!noticia.Ativo)
                    return BadRequest($"Notícia '{noticia.Titulo}' já está inativa!");

                noticia.Inativar();

                await _rep.Save();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }

    public class NoticiaDto
    {
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public string Imagem { get; set; }
        public int Prioridade { get; set; }
        public Guid CodigoCategoria { get; set; }
    }
}
