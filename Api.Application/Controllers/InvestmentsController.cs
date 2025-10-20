using Api.Domain.Interfaces.Services.Investiment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentsController : ControllerBase
    {
        private IInvestmentRepository _service;
        public InvestmentsController(IInvestmentRepository service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 - Bad Request - Requisição inválida
            }
            try
            {
                var investments = await _service.GetAllAsync();
                if (investments == null || !investments.Any())
                {
                    return NoContent(); // 204 - No Content - Requisição bem-sucedida, mas sem conteúdo para retornar
                }
                return Ok(investments); // 200 - OK - Requisição bem-sucedida
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); // 500 - Internal Server Error - Erro interno do servidor
            }
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 - Bad Request - Requisição inválida
            }
            try
            {
                var investment = await _service.GetByIdAsync(id);
                if (investment == null)
                {
                    return NoContent(); // 204 - No Content - Requisição bem-sucedida, mas sem conteúdo para retornar
                }
                return Ok(investment); // 200 - OK - Requisição bem-sucedida
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); // 500 - Internal Server Error - Erro interno do servidor
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Domain.Entities.InvestmentEntity investment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 - Bad Request - Requisição inválida
            }
            try
            {
                var createdInvestment = await _service.CreateAsync(investment);
                if (createdInvestment == null)
                {
                    return NoContent(); // 204 - No Content - Requisição bem-sucedida, mas sem conteúdo para retornar
                }
                return Ok(createdInvestment); // 200 - OK - Requisição bem-sucedida
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); // 500 - Internal Server Error - Erro interno do servidor
            }
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put([FromBody] Domain.Entities.InvestmentEntity investment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 - Bad Request - Requisição inválida
            }
            try
            {
                var updatedInvestment = await _service.UpdateAsync(investment);
                if (updatedInvestment == null)
                {
                    return NoContent(); // 204 - No Content - Requisição bem-sucedida, mas sem conteúdo para retornar
                }
                return Ok(updatedInvestment); // 200 - OK - Requisição bem-sucedida
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); // 500 - Internal Server Error - Erro interno do servidor
            }
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 - Bad Request - Requisição inválida
            }
            try
            {
                var result = await _service.DeleteAsync(id);
                if (!result)
                {
                    return NotFound(); // 404 - Not Found - Recurso não encontrado
                }
                return NoContent(); // 204 - No Content - Requisição bem-sucedida, mas sem conteúdo para retornar
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); // 500 - Internal Server Error - Erro interno do servidor
            }
        }

    }
}
