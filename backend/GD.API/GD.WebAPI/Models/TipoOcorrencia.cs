namespace GD.API.Models
{
    public class TipoOcorrencia
    {
        public int Id { get; set; } // Id (Primary key)
        public int OcorrenciaId { get; set; } // OcorrenciaId
        public string Nome { get; set; } // Nome (length: 64)
        public string Codigo { get; set; } // Codigo (length: 3)
    }
}
