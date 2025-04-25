using ApiTesteThoth.Data;
using ApiTesteThoth.DTOs;
using ApiTesteThoth.Entities;
using BCrypt.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

        public async Task<string> LoginAsync(UsuarioDTO dto)
        {
            var user = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.NomeDeUsuario == dto.NomeDeUsuario);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Senha, user.Senha))
                throw new Exception("Usuário ou senha inválidos");

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name,           user.NomeDeUsuario),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Id.ToString())

            };

            var creds = new SigningCredentials(
                new SymmetricSecurityKey(_key),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
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
