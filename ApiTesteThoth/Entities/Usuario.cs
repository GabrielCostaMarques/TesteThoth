namespace ApiTesteThoth.Entities
{
    public class Usuario
    {
        public int Id { get; set; } 
        public string NomeDeUsuario { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public ICollection<Compromisso> Compromissos { get; set; } = new List<Compromisso>();
    }
}
