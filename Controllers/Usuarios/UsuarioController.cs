using Blog.Dominio.Usuarios;
using Blog.Dominio.Usuarios.Validadores;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers.Usuarios
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        #region CTor
        private readonly IRepUsuario _rep;
        private readonly IValidadorUsuario _validador;

        public UsuarioController(IRepUsuario rep, 
            IValidadorUsuario validador)
        {
            _rep = rep;
            _validador = validador;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> RecuperarTodosUsuarios()
        {
            try
            {
                var usuarios = await _rep.Get();

                return Ok(usuarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RecuperarUsuario(Guid id)
        {
            try
            {
                var usuario = await _rep.Get(id);

                return Ok(usuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
