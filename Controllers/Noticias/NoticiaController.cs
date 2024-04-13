using Blog.Dominio.Noticias;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers.Noticias
{
    [ApiController]
    [Route("[Controller]")]
    public class NoticiaController : ControllerBase
    {
        #region CTor
        private readonly IRepNoticia _rep;

        public NoticiaController(IRepNoticia rep)
        {
            _rep = rep;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> RecuperarTodasNoticias()
        {
            try
            {
                var noticia = await _rep.GetIncludingCategoria();

                return Ok(noticia);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RecuperarNoticia(Guid id)
        {
            try
            {
                var noticia = await _rep.Get(id);

                return Ok(noticia);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
