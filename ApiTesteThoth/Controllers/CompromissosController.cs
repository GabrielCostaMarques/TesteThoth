using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ApiTesteThoth.DTOs;
using ApiTesteThoth.Entities;
using ApiTesteThoth.Services;

namespace ApiTesteThoth.Controllers
{
    [ApiController]
    [Route("api/Compromissos")]
    [Authorize]
    public class CompromissosController : ControllerBase
    {
        private readonly ICompromissoService _compromissoContext;
        public CompromissosController(ICompromissoService compromissoContext) => _compromissoContext = compromissoContext;

        private int UserId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _compromissoContext.GetAllAsync(UserId));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var c = await _compromissoContext.GetByIdAsync(UserId, id);
            return c == null ? NotFound() : Ok(c);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompromissoDTO dto)
        {
            var c = await _compromissoContext.CreateAsync(UserId, dto);
            return CreatedAtAction(nameof(Get), new { id = c.Id }, c);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CompromissoDTO dto)
        {
            try
            {
                await _compromissoContext.UpdateAsync(UserId, id, dto);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _compromissoContext.DeleteAsync(UserId, id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
