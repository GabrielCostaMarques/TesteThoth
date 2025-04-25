using ApiTesteThoth.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiTesteThoth.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        protected Context()
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Compromisso> Compromissos { get; set; }
    }
}

