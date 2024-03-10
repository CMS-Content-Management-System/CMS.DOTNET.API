using Blog.Dominio.Usuarios.Validadores;
using Blog.Dominio.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers.Usuarios
{
    [ApiController]
    [Route("[Controller]")]
    public class AdmUsuarioController : ControllerBase
    {
        #region CTor
        private readonly IRepUsuario _rep;
        private readonly IValidadorUsuario _validador;

        public AdmUsuarioController(IRepUsuario rep,
            IValidadorUsuario validador)
        {
            _rep = rep;
            _validador = validador;
        }
        #endregion


        [HttpPost]
        public async Task<IActionResult> InserirUsuario(UsuarioDto dto)
        {
            try
            {
                var usuario = new Usuario(dto.Nome, dto.SobreNome, dto.Email);

                _validador.ValidarSePodeInserir(usuario);

                _rep.Add(usuario);

                await _rep.Save();

                return Ok(usuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarUsuario(Guid id, UsuarioDto dto)
        {
            try
            {
                var usuario = await _rep.Get(id);

                if (usuario == null)
                    return BadRequest($"Usuario de código '{id}' não existe!");

                usuario.AlterarDados(dto.Nome, dto.SobreNome, dto.Email);

                _validador.ValidarAlteracaoDados(usuario);

                await _rep.Save();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut("{id}/ativar")]
        public async Task<IActionResult> Ativar(Guid id)
        {
            try
            {
                var usuario = await _rep.Get(id);

                if (usuario == null)
                    return BadRequest($"Usuário de código '{id}' não existe!");

                if (usuario.Ativo)
                    return BadRequest($"Usuario '{usuario.Nome}' já está ativo!");

                usuario.Ativar();

                await _rep.Save();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}/inativar")]
        public async Task<IActionResult> Inativar(Guid id)
        {
            try
            {
                var usuario = await _rep.Get(id);

                if (usuario == null)
                    return BadRequest($"Usuário de código '{id}' não existe!");

                if (!usuario.Ativo)
                    return BadRequest($"Usuário '{usuario.Nome}' já está inativo");

                _validador.ValidarSePodeInativar(usuario);

                usuario.Inativar();

                await _rep.Save();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverUsuario(Guid id)
        {
            try
            {
                var usuario = await _rep.Get(id);

                if (usuario == null)
                    return BadRequest($"Usuario de código '{id}' não existe!");

                _validador.ValidarSePodeRemover(usuario);

                await _rep.Delete(id);
                await _rep.Save();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }

    public class UsuarioDto
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
    }
}
