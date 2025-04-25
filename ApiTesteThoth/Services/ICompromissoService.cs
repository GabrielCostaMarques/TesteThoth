using ApiTesteThoth.DTOs;
using ApiTesteThoth.Entities;

namespace ApiTesteThoth.Services
{
    public interface ICompromissoService
    {
        Task<Compromisso> CreateAsync(int userId, CompromissoDTO dto);
        Task<IEnumerable<Compromisso>> GetAllAsync(int userId);
        Task<Compromisso?> GetByIdAsync(int userId, int id);
        Task UpdateAsync(int userId, int id, CompromissoDTO dto);
        Task DeleteAsync(int userId, int id);
    }
}
