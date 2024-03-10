using Blog.Dominio.Categorias;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers.Categorias
{
    [ApiController]
    [Route("[Controller]")]
    public class CategoriaController : ControllerBase
    {
        #region CTor
        private readonly IRepCategoria _rep;

        public CategoriaController(IRepCategoria rep)
        {
            _rep = rep;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> RecuperarTodasCategorias()
        {
            try
            {
                var categorias = await _rep.Get();

                return Ok(categorias);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RecuperarCategoria(Guid id)
        {
            try
            {
                var categoria = await _rep.Get(id);

                return Ok(categoria);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
