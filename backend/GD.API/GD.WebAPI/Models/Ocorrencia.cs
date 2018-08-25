namespace GD.API.Models
{
    public class Ocorrencia
    {
        public int Id { get; set; } // Id (Primary key)
        public string Codigo { get; set; } // Codigo (length: 3)
        public string Nome { get; set; } // Nome (length: 64)
    }
}
