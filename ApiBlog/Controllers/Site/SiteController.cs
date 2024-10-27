using ApiBlog.Dominio.Bases;
using ApiBlog.Dominio.Categorias;
using ApiBlog.Dominio.Noticias;
using ApiBlog.Dominio.Parametrizacoes.Geral;
using ApiBlog.Dominio.Propagandas;
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
        private readonly IRepConfigGeral _repConfigGeral;
        private readonly IRepPropaganda _repPropaganda;

        public SiteController(IRepCategoria repCategoria,
            IRepNoticia repNoticia,
            IRepUsuario repUsuario,
            IRepConfigGeral repConfigGeral,
            IRepPropaganda repPropaganda)
        {
            _repCategoria = repCategoria;
            _repNoticia = repNoticia;
            _repUsuario = repUsuario;
            _repConfigGeral = repConfigGeral;
            _repPropaganda = repPropaganda;
        }
        #endregion

        [HttpGet("config-geral")]
        public async Task<IActionResult> RecuperarConfiguracao()
        {
            try
            {
                var configuracao = await _repConfigGeral.GetView();

                return Ok(configuracao);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("categoria")]
        public async Task<IActionResult> RecuperarTodasCategorias([FromQuery] QueryParams queryParams)
        {
            try
            {
                var categorias = await _repCategoria.GetView(queryParams);
                var total = await _repCategoria.Count(queryParams);

                var ret = new
                {
                    Content = categorias,
                    Total = total
                };

                return Ok(ret);
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
        public async Task<IActionResult> RecuperarTodasNoticias([FromQuery] QueryParams queryParams)
        {
            try
            {
                var noticias = await _repNoticia.GetView(queryParams);
                var total = await _repNoticia.Count(queryParams);

                var ret = new
                {
                    Content = noticias,
                    Total = total
                };

                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("noticia-pesquisa/{palavra}")]
        public async Task<IActionResult> PesquisarNoticias([FromRoute] string palavra, [FromQuery] QueryParams queryParams)
        {
            try
            {
                var noticias = await _repNoticia.ConsultarPalavraView(palavra, queryParams);
                var total = await _repNoticia.Count(palavra, queryParams);

                var ret = new
                {
                    Content = noticias,
                    Total = total
                };

                return Ok(ret);
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
        public async Task<IActionResult> RecuperarTodosUsuarios([FromQuery] QueryParams queryParams)
        {
            try
            {
                var usuarios = await _repUsuario.GetView(queryParams);
                var total = await _repUsuario.Count(queryParams);

                var ret = new
                {
                    Content = usuarios,
                    Total = total
                };

                return Ok(ret);
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

        [HttpGet("propaganda")]
        public async Task<IActionResult> RecuperarTodasPropagandas([FromQuery] QueryParams queryParams)
        {
            try
            {
                var propagandas = await _repPropaganda.GetView(queryParams);
                var total = await _repPropaganda.Count(queryParams);

                var ret = new
                {
                    Content = propagandas,
                    Total = total
                };

                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("propaganda/{id}")]
        public async Task<IActionResult> RecuperarPropaganda(Guid id)
        {
            try
            {
                var propaganda = await _repPropaganda.GetView(id);

                return Ok(propaganda);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}