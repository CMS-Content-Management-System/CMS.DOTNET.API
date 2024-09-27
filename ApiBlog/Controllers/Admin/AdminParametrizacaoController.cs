using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApiBlog.Dominio.Parametrizacoes.Geral;

namespace ApiBlog.Controllers.Admin
{
    [ApiController]
    [Route("api/admin-parametrizacao")]
    public class AdminParametrizacaoController : ControllerBase
    {
        #region CTor
        private readonly IRepConfigGeral _rep;

        public AdminParametrizacaoController(IRepConfigGeral rep)
        {
            _rep = rep;
        }
        #endregion

        [Authorize]
        [HttpPut("geral")]
        public async Task<IActionResult> AlterarConfigGeral(ConfigGeralDto dto)
        {
            try
            {
                var config = await _rep.Get();

                if (config == null)
                {
                    config = new ConfigGeral(dto.NomeSite, dto.ImagemSite, dto.Nome, dto.Fone, dto.Email,
                        dto.Endereco, dto.Instagram, dto.Facebook);
                }
                else
                {
                    config.Alterar(dto.NomeSite, dto.ImagemSite, dto.Nome, dto.Fone, dto.Email,
                        dto.Endereco, dto.Instagram, dto.Facebook);
                }

                await _rep.Save();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }

    public class ConfigGeralDto
    {
        public string NomeSite { get; set; }
        public string ImagemSite { get; set; }
        public string Nome { get; set; }
        public string Fone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
    }
}
