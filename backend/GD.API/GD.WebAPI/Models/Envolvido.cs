namespace GD.API.Models
{
    public class Envolvido
    {
        public int Id { get; set; } // Id (Primary key)
        public string Nome { get; set; } // Nome (length: 128)
        public int Idade { get; set; } // Idade
        public int IdQualidade { get; set; } // IdQualidade
        public string Endereco { get; set; } // Endereco (length: 256)
        public int IdRegistroOcorrencia { get; set; } // IdRegistroOcorrencia
        public string RG { get; set; }
    }
}
