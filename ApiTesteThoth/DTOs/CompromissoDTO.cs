﻿namespace ApiTesteThoth.DTOs
{
    public class CompromissoDTO
    {
        public string Nome { get; set; } =string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime Data { get; set; } = DateTime.Now;
    }
}
