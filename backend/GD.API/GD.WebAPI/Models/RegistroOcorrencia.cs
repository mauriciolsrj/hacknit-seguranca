namespace GD.API.Models
{
    public class RegistroOcorrencia
    {
        public int Id { get; set; } // Id (Primary key)
        public int IdOcorrencia { get; set; } // IdOcorrencia
        public int IdTipoOcorrencia { get; set; } // IdTipoOcorrencia
        public decimal? Latitude { get; set; } // Latitude
        public decimal? Longitude { get; set; } // Longitude
        public System.DateTime Inicio { get; set; } // Inicio
        public string Endereco { get; set; } // Endereco (length: 256)
        public string HistoricoOcorrencia { get; set; } // HistoricoOcorrencia
        public bool EncerradoNoLocal { get; set; } // EncerradoNoLocal
        public bool ConduzidoAdp { get; set; } // ConduzidoADP
        public bool ApreensaoMaterial { get; set; } // ApreensaoMaterial
        public System.DateTime? Fim { get; set; } // Fim
        public int? Ro { get; set; } // RO
        public bool Flagrante { get; set; } // Flagrante
        public int? Lacre { get; set; } // Lacre

        public RegistroOcorrencia()
        {
            EncerradoNoLocal = false;
            ConduzidoAdp = false;
            ApreensaoMaterial = false;
            Flagrante = false;
        }
    }
}
