using CRUD_API_CONFERIR.Model;
using CRUD_API_CONFERIR.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_API_CONFERIR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DadosController : ControllerBase
    {
        private readonly DadosServices _dadosService;

        public DadosController(DadosServices dadosServices)
        {
            _dadosService = dadosServices;
        }

        [HttpGet]
        public async Task<List<Dados>> Get() =>
            await _dadosService.GetAsync();
        [HttpGet("{cpf:length(11)}")]
        public async Task<ActionResult<Dados>> Get(string cpf)
        {
            var dados = await _dadosService.GetAsync(cpf);
            if (dados is null)
            {
                return NotFound();
            }
            return dados;

        }
        [HttpPost]
        public async Task<IActionResult> Post(Dados newDados)
        {
            await _dadosService.CreateAsync(newDados);

            return CreatedAtAction(nameof(Get), new { cpf = newDados.Cpf }, newDados);
        }

        [HttpPut("{cpf:length(11)}")]
        public async Task<IActionResult> Update(string cpf, Dados updatedDados)
        {
            var dados = await _dadosService.GetAsync(cpf);
            if (dados is null)
            { return NotFound();}
            updatedDados.Cpf = dados.Cpf;

            await _dadosService.UpdateAsync(cpf, updatedDados);
            return NoContent();

        }
        
        [HttpDelete("{cpf:length(11)}")]
        public async Task<IActionResult> Delete(string cpf)
        {
            var dados = await _dadosService.GetAsync(cpf);

            if (dados is null)
            {
                return NotFound();
            }

            await _dadosService.RemoveAsync(cpf);

            return NoContent();
        }

    }
}
