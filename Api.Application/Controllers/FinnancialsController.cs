using Api.Domain.Interfaces.Services.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinnancialsController : ControllerBase
    {
        private IFinnancialAccountRepository _service;

        public FinnancialsController(IFinnancialAccountRepository service)
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
                var accounts = await _service.GetAllAsync();
                if (accounts == null || !accounts.Any())
                {
                    return NoContent(); // 204 - No Content - Requisição bem-sucedida, mas sem conteúdo para retornar
                }
                return Ok(accounts); // 200 - OK - Requisição bem-sucedida
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
                var account = await _service.GetByIdAsync(id);
                if (account == null)
                {
                    return NoContent(); // 204 - No Content - Requisição bem-sucedida, mas sem conteúdo para retornar
                }
                return Ok(account); // 200 - OK - Requisição bem-sucedida
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); // 500 - Internal Server Error - Erro interno do servidor
            }
        }
      
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Domain.Entities.FinancialAccountEntity account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 - Bad Request - Requisição inválida
            }
            try
            {
                var createdAccount = await _service.CreateAsync(account, account.CategoryId);
                return CreatedAtAction(nameof(GetById), new { id = createdAccount.Id }, createdAccount); // 201 - Created - Recurso criado com sucesso
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); // 500 - Internal Server Error - Erro interno do servidor
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Domain.Entities.FinancialAccountEntity account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 - Bad Request - Requisição inválida
            }
            try
            {
                var updatedAccount = await _service.UpdateAsync(account);
                return Ok(updatedAccount); // 200 - OK - Requisição bem-sucedida
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
                var deleted = await _service.DeleteAsync(id);
                if (deleted)
                {
                    return Ok(); // 200 - OK - Requisição bem-sucedida
                }
                else
                {
                    return NotFound(); // 404 - Not Found - Recurso não encontrado
                }
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); // 500 - Internal Server Error - Erro interno do servidor
            }
        }
    
    }
}
