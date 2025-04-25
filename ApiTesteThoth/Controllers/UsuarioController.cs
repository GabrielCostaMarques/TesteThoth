using ApiTesteThoth.DTOs;
using ApiTesteThoth.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiTesteThoth.Controllers
{

    [ApiController]
    [Route("Usuario/auth")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService) => _usuarioService = usuarioService;


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UsuarioDTO dto)
        {
            var user = await _usuarioService.RegisterAsync(dto);
            return CreatedAtAction(null, new { Id = user.Id, NomeDeUsuario = user.NomeDeUsuario });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioDTO dto)
        {
            try
            {
                var token = await _usuarioService.LoginAsync(dto);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
