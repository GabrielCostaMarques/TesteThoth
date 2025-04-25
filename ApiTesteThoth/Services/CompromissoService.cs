using ApiTesteThoth.Data;
using ApiTesteThoth.DTOs;
using ApiTesteThoth.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;
namespace ApiTesteThoth.Services
{
    public class CompromissoService :ICompromissoService
    {
        private readonly Context _context;
        public CompromissoService(Context context) =>_context = context;
        

        public async Task<Compromisso> CreateAsync(int userId, CompromissoDTO dto)
        {
            var compromisso = new Compromisso
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Data = dto.Data,
                UsuarioId = userId
            };

            _context.Add(compromisso);  
            await _context.SaveChangesAsync();

            return compromisso;
        }


        public async Task<IEnumerable<Compromisso>> GetAllAsync(int userId)
        {
            return await _context.Set<Compromisso>()
                 .Where(c => c.UsuarioId == userId)
                 .ToListAsync();    
        }
        
        
        public async Task<Compromisso?> GetByIdAsync(int userId, int id)
        {
            return await _context.Set<Compromisso>()
                .FirstOrDefaultAsync(c => c.Id == id && c.UsuarioId == userId);
        }


        public async Task UpdateAsync(int userId, int id, CompromissoDTO dto)
        {
            var compromisso = await GetByIdAsync(userId, id) ?? throw new Exception("Comprimisso não encontrado");
            
            compromisso.Nome = dto.Nome;
            compromisso.Descricao = dto.Descricao;
            compromisso.Data = dto.Data;

            await _context.SaveChangesAsync();
        }

        
        public async Task DeleteAsync(int userId, int id)
        {
            var compromisso = await GetByIdAsync(userId, id) ?? throw new Exception("Comprimisso não encontrado");
            
            _context.Remove(compromisso);
            await _context.SaveChangesAsync();
        }


    }
}
