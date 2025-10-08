using System.Net;
using Api.Domain.Interfaces.Services.Category;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryRepository _service;

        public CategoriesController(ICategoryRepository service)
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
                var users = await _service.GetAllAsync();
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
        [Route("{id}", Name = "GetCategoryById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 - Bad Request - Requisição inválida
            }
            try
            {
                var user = await _service.GetByIdAsync(id);
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
        public async Task<IActionResult> Post([FromBody] CategoryEntity user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 - Bad Request - Requisição inválida
            }
            try
            {
                var createdCategory = await _service.CreateAsync(user);
                return CreatedAtRoute("GetCategoryById", new { id = createdCategory.Id }, createdCategory); // 201 - Created - Recurso criado com sucesso
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); // 500 - Internal Server Error - Erro interno do servidor
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CategoryEntity user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 - Bad Request - Requisição inválida
            }
            try
            {
                var updatedUser = await _service.UpdateAsync(user);
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
        [HttpDelete("{id}")]
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
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); // 500 - Internal Server Error - Erro interno do servidor
            }
        }
    }
}
