namespace GD.API.Models
{
    public class RelatorioGeoOcorrencias
    {
        public int Id { get; set; } // Id
        public decimal? Latitude { get; set; } // Latitude
        public decimal? Longitude { get; set; } // Longitude
        public System.DateTime Inicio { get; set; } // Inicio
        public System.DateTime? Fim { get; set; } // Fim
        public string Ocorrencia { get; set; } // Ocorrencia (length: 64)
        public int? IdOcorrencia { get; set; } // IdOcorrencia
        public string Tipo { get; set; } // Tipo (length: 64)
        public int? IdTipoOcorrencia { get; set; } // IdTipoOcorrencia
    }
}
