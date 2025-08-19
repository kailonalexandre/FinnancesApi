
using System.Net;
using Api.Domain.Interfaces.Services.User;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private IUserService _service;
        public UsersController(IUserService service)
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
                var users = await _service.GetAll();
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

        // GET api/users/{id}

        [HttpGet]
        [Route("{id}", Name = "GetUserById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 - Bad Request - Requisição inválida
            }
            try
            {
                var user = await _service.Get(id);
                if (user == null)
                {
                    return NotFound(); // 404 - Not Found - Recurso não encontrado
                }
                return Ok(user); // 200 - OK - Requisição bem-sucedida
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); // 500 - Internal Server Error - Erro interno do servidor
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 - Bad Request - Requisição inválida
            }
            try
            {
                var createdUser = await _service.Post(user);
                return CreatedAtRoute("GetUserById", new { id = createdUser.Id }, createdUser); // 201 - Created - Recurso criado com sucesso
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); // 500 - Internal Server Error - Erro interno do servidor
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 - Bad Request - Requisição inválida
            }
            try
            {
                var updatedUser = await _service.Put(user);
                if (updatedUser == null)
                {
                    return NotFound(); // 404 - Not Found - Recurso não encontrado
                }
                return Ok(updatedUser); // 200 - OK - Requisição bem-sucedida
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); // 500 - Internal Server Error - Erro interno do servidor
            }
        }
        [HttpDelete ("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 - Bad Request - Requisição inválida
            }
            try
            {
                var result = await _service.Delete(id);
                if (!result)
                {
                    return NotFound(); // 404 - Not Found - Recurso não encontrado
                }
                return NoContent(); // 204 - No Content - Requisição bem-sucedida, mas sem conteúdo para retornar
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); // 500 - Internal Server Error - Erro interno do servidor
            }
        }
    }
}