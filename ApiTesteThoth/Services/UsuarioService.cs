using ApiTesteThoth.Data;
using ApiTesteThoth.DTOs;
using ApiTesteThoth.Entities;
using BCrypt.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace ApiTesteThoth.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly Context _context;
        private readonly byte[] _key;

        public UsuarioService(Context context)
        {
            _context = context;
            _key = Encoding.UTF8.GetBytes("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c");
        }

        public Task<string> LoginAsync(UsuarioDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> RegisterAsync(UsuarioDTO dto)
        {
            var hashed = BCrypt.Net.BCrypt.HashPassword(dto.Senha);
            var user = new Usuario { NomeDeUsuario = dto.NomeDeUsuario, Senha = hashed };
            _context.Add(user);
            await _context.SaveChangesAsync();


            return user;
        }
    }
}
