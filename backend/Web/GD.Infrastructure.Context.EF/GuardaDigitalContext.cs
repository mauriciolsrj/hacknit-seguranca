using GD.Entity;
using GD.Infrastructure.Context.EF.Configurations;
using System.Data.Entity;

namespace GD.Infrastructure.Context.EF
{
    public class GuardaDigitalContext : DbContext
    {
        public GuardaDigitalContext() : base("name=DefaultConnection")
        {

        }

        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Lotacao> Lotacao { get; set; }
        public virtual DbSet<Envolvido> Envolvido { get; set; }
        public virtual DbSet<Ocorrencia> Ocorrencia { get; set; }
        public virtual DbSet<RelatorioTipoOcorrencia> TipoOcorrencia { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AspNetRolesConfiguration());
            modelBuilder.Configurations.Add(new AspNetUserClaimsConfiguration());
            modelBuilder.Configurations.Add(new AspNetUserLoginsConfiguration());
            modelBuilder.Configurations.Add(new AspNetUsersConfiguration());
            //modelBuilder.Configurations.Add(new EnvolvidoConfiguration());
            //modelBuilder.Configurations.Add(new GuardaRoConfiguration());
            //modelBuilder.Configurations.Add(new LotacaoConfiguration());
            modelBuilder.Configurations.Add(new OcorrenciaConfiguration());
            //modelBuilder.Configurations.Add(new QualidadeEnvolvidoConfiguration());
            //modelBuilder.Configurations.Add(new RegistroOcorrenciaConfiguration());
            //modelBuilder.Configurations.Add(new RelatorioGeoOcorrenciasConfiguration());
            modelBuilder.Configurations.Add(new RelatorioTipoOcorrenciaConfiguration());
            //modelBuilder.Configurations.Add(new TipoOcorrenciaConfiguration());
        }
    }
}
