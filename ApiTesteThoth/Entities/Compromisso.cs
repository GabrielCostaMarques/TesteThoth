using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTesteThoth.Entities
{
    public class Compromisso
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime Data { get; set; } = DateTime.Now.Date;
        public int UsuarioId { get; set; }
    }
}
