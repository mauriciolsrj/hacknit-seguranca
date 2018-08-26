using GD.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD.Infrastructure.Context.EF.Configurations
{
    public class OcorrenciaConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Ocorrencia>
    {
        public OcorrenciaConfiguration()
            : this("dbo")
        {
        }

        public OcorrenciaConfiguration(string schema)
        {
            ToTable(schema + ".Ocorrencia");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Codigo).HasColumnName("Codigo").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(3);
            Property(x => x.Nome).HasColumnName("Nome").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(64);
        }
    }
}
