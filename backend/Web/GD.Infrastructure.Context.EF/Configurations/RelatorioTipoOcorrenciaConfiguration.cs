using GD.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD.Infrastructure.Context.EF.Configurations
{
    public class RelatorioTipoOcorrenciaConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<RelatorioTipoOcorrencia>
    {
        public RelatorioTipoOcorrenciaConfiguration()
            : this("dbo")
        {
        }

        public RelatorioTipoOcorrenciaConfiguration(string schema)
        {
            ToTable(schema + ".RelatorioTipoOcorrencia");
            HasKey(x => new { x.Tipo, x.Codigo, x.Ocorrencia });

            Property(x => x.Tipo).HasColumnName("Tipo").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(64);
            Property(x => x.Codigo).HasColumnName("Codigo").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(3);
            Property(x => x.Ocorrencia).HasColumnName("Ocorrencia").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(64);
        }
    }
}
