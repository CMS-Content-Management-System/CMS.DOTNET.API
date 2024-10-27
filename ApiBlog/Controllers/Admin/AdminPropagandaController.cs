using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApiBlog.Dominio.Propagandas;

namespace ApiBlog.Controllers.Admin
{

    [ApiController]
    [Route("api/admin-propaganda")]
    public class AdminPropagandaController : ControllerBase
    {
        #region CTor
        private readonly IRepPropaganda _rep;

        public AdminPropagandaController(IRepPropaganda rep)
        {
            _rep = rep;
        }
        #endregion

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> InserirPropaganda(PropagandaDto dto)
        {
            try
            {
                var propaganda = new Propaganda(dto.Titulo, dto.Imagem, dto.Link, dto.Prioridade);

                _rep.Add(propaganda);

                await _rep.Save();

                return Ok(propaganda);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarPropaganda(Guid id, PropagandaDto dto)
        {
            try
            {
                var propaganda = await _rep.Get(id);

                if (propaganda == null)
                    return BadRequest($"Propaganda de código '{id}' não existe!");

                propaganda.AlterarDados(dto.Titulo, dto.Imagem, dto.Link, dto.Prioridade);

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
        public async Task<IActionResult> RemoverPropaganda(Guid id)
        {
            try
            {
                var propaganda = await _rep.Get(id);

                if (propaganda == null)
                    return BadRequest($"Propaganda de código '{id}' não existe!");

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
                var propaganda = await _rep.Get(id);

                if (propaganda == null)
                    return BadRequest($"Propaganda de código '{id}' não existe!");

                if (propaganda.Ativo)
                    return BadRequest($"Propaganda '{propaganda.Titulo}' já está ativa!");

                propaganda.Ativar();

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
                var propaganda = await _rep.Get(id);

                if (propaganda == null)
                    return BadRequest($"Propaganda de código '{id}' não existe!");

                if (!propaganda.Ativo)
                    return BadRequest($"Propaganda '{propaganda.Titulo}' já está inativa!");

                propaganda.Inativar();

                await _rep.Save();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }

    public class PropagandaDto
    {
        public string Titulo { get; set; }
        public string Imagem { get; set; }
        public string Link { get; set; }
        public int Prioridade { get; set; }
    }
}
