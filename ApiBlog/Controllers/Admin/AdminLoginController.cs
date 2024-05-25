using ApiBlog.Dominio.Geral;
using ApiBlog.Dominio.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiBlog.Controllers.Admin
{
    [ApiController]
    [Route("api/admin-login")]
    public class AdminLoginController : ControllerBase
    {
        private readonly IRepUsuario _repUsuario;
        private readonly ITokenService _tokenService;

        private readonly IConfiguration _config;

        public AdminLoginController(IRepUsuario repUsuario,
            ITokenService tokenService,
            IConfiguration config)
        {
            _repUsuario = repUsuario;
            _tokenService = tokenService;
            _config = config;
        }

        [HttpPut("gerar-token")]
        public async Task<IActionResult> GerarToken(LoginDto dto)
        {
            try
            {
                var usuario = await _repUsuario.RecuperarUsuarioLogin(dto.Email, dto.Senha);

                if (usuario == null)
                    return BadRequest($"E-mail ou senha inválido!");

                var token = _tokenService.Gerar(usuario);

                return Ok(token);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpGet("validar-token")]
        public async Task<IActionResult> ValidarToken()
        {
            try
            {
                var idUsuario = User.Claims.FirstOrDefault(x => x.Type == "IdUsuario")?.Value;

                if (idUsuario == null)
                    return BadRequest();

                var guidUsuario = Guid.Parse(idUsuario);

                var usuario = await _repUsuario.Get(guidUsuario);

                if (usuario == null)
                    return BadRequest();

                return Ok(usuario.Nome);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
/*
        [HttpGet("testeDDD01")]
        public async Task<IActionResult> TesteDDD01()
        {
            try
            {
                return Ok(_config["DDD01"]);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("testeDDD02")]
        public async Task<IActionResult> TesteDDD02()
        {
            try
            {
                return Ok(_config["DDD02:DDD02-01"]);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }*/
    }

    public class LoginDto
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
