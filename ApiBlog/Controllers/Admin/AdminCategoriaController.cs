using ApiBlog.Dominio.Categorias;
using ApiBlog.Dominio.Categorias.Validadores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiBlog.Controllers.Admin
{
    [ApiController]
    [Route("api/admin-categoria")]
    public class AdminCategoriaController : ControllerBase
    {
        #region CTor
        private readonly IRepCategoria _rep;
        private readonly IValidadorCategoria _validadorCategoria;

        public AdminCategoriaController(IRepCategoria repCategoria, 
            IValidadorCategoria validadorCategoria)
        {
            _rep = repCategoria;
            _validadorCategoria = validadorCategoria;
        }
        #endregion

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> InserirCategoria(CategoriaDto dto)
        {
            try
            {
                var categoria = new Categoria(dto.Descricao);

                _rep.Add(categoria);

                await _rep.Save();

                return Ok(categoria);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpPut("{id}/alterar-descricao-tttt")]
        public async Task<IActionResult> AlterarDescricaoCategoria(Guid id, CategoriaDto dto)
        {
            try
            {
                var categoria = await _rep.Get(id);

                if (categoria == null)
                    throw new Exception($"Categoria de código '{id}' não existe!");

                categoria.AlterarDescricao(dto.Descricao);

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
        public async Task<IActionResult> RemoverCategoria(Guid id)
        {
            try
            {
                var categoria = await _rep.Get(id);

                if (categoria == null)
                    return BadRequest($"Categoria de código '{id}' não existe!");

                _validadorCategoria.ValidarSePodeRemover(categoria);

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
                var categoria = await _rep.Get(id);

                if (categoria == null)
                    return BadRequest($"Categoria de código '{id}' não existe!");

                if (categoria.Ativo)
                    return BadRequest($"Categoria '{categoria.Descricao}' já está ativa!");

                categoria.Ativar();

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
                var categoria = await _rep.Get(id);

                if (categoria == null)
                    return BadRequest($"Categoria de código '{id}' não existe!");

                if (!categoria.Ativo)
                    return BadRequest($"Categoria '{categoria.Descricao}' já está inativa!");

                _validadorCategoria.ValidarSePodeInativar(categoria);

                categoria.Inativar();

                await _rep.Save();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public class CategoriaDto
        {
            public string Descricao { get; set; }
        }

    }
}
