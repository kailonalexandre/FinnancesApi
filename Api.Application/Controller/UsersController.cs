
using System.Net;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IUserService service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 - Bad Request - Requisição inválida
            }
            try
            {
                var users = await service.GetAll();
                if (users == null || !users.Any())
                {
                    return NoContent(); // 204 - No Content - Requisição bem-sucedida, mas sem conteúdo para retornar
                }
                return Ok(users); // 200 - OK - Requisição bem-sucedida
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); // 500 - Internal Server Error - Erro interno do servidor
            }
        }
    }
}