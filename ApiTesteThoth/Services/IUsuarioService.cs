using ApiTesteThoth.DTOs;
using ApiTesteThoth.Entities;

namespace ApiTesteThoth.Services
{
    public interface IUsuarioService
    {
        Task<Usuario> RegisterAsync(UsuarioDTO dto);
        Task<string> LoginAsync(UsuarioDTO dto);
    }
}
