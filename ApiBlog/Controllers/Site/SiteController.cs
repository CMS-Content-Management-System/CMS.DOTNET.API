using ApiBlog.Dominio.Categorias;
using ApiBlog.Dominio.Noticias;
using ApiBlog.Dominio.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace ApiBlog.Controllers.Site
{
    [ApiController]
    [Route("api/site")]
    public class SiteController : ControllerBase
    {
        #region CTor
        private readonly IRepCategoria _repCategoria;
        private readonly IRepNoticia _repNoticia;
        private readonly IRepUsuario _repUsuario;

        public SiteController(IRepCategoria repCategoria,
            IRepNoticia repNoticia,
            IRepUsuario repUsuario)
        {
            _repCategoria = repCategoria;
            _repNoticia = repNoticia;
            _repUsuario = repUsuario;
        }
        #endregion

        [HttpGet("categoria")]
        public async Task<IActionResult> RecuperarTodasCategorias()
        {
            try
            {
                var categorias = await _repCategoria.GetView();

                return Ok(categorias);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("categoria/{id}")]
        public async Task<IActionResult> RecuperarCategoria(Guid id)
        {
            try
            {
                var categoria = await _repCategoria.GetView(id);

                return Ok(categoria);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("noticia")]
        public async Task<IActionResult> RecuperarTodasNoticias()
        {
            try
            {
                var noticias = await _repNoticia.GetView();

                return Ok(noticias);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("noticia/{id}")]
        public async Task<IActionResult> RecuperarNoticia(Guid id)
        {
            try
            {
                var noticia = await _repNoticia.GetView(id);

                return Ok(noticia);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        [HttpGet("usuario")]
        public async Task<IActionResult> RecuperarTodosUsuarios()
        {
            try
            {
                var usuarios = await _repUsuario.GetView();

                return Ok(usuarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("usuario/{id}")]
        public async Task<IActionResult> RecuperarUsuario(Guid id)
        {
            try
            {
                var usuario = await _repUsuario.GetView(id);

                return Ok(usuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}