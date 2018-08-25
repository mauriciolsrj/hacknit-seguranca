namespace GD.API.Models
{
    public class RegistroOcorrenciaModel
    {
        public RegistroOcorrencia Registro { get; set; }
        public Envolvido[] Envolvidos { get; set; }
        public string[] Matriculas { get; set; }
    }
}
