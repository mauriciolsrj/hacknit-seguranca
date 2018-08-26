using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD.Entity
{
    public class RelatorioTipoOcorrencia
    {
        public string Tipo { get; set; } // Tipo (length: 64)
        public string Codigo { get; set; } // Codigo (length: 3)
        public string Ocorrencia { get; set; } // Ocorrencia (length: 64)
    }
}
