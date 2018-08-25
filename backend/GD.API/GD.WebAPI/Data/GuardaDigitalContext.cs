using GD.API.Models;
using Microsoft.EntityFrameworkCore;


namespace GD.API.Data
{
    public partial class GuardaDigitalContext : DbContext
    {
        public GuardaDigitalContext()
        {
        }


        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Lotacao> Lotacao { get; set; }
        public virtual DbSet<Envolvido> Envolvido { get; set; }
        public virtual DbSet<Ocorrencia> Ocorrencia { get; set; }
        public virtual DbSet<RegistroOcorrencia> RegistroOcorrencia { get; set; }
        public virtual DbSet<TipoOcorrencia> TipoOcorrencia { get; set; }
        public virtual DbSet<RelatorioGeoOcorrencias> RelatorioGeoOcorrencias { get; set; }
        public virtual DbSet<GuardaRo> GuardaRO { get; set; }


        public GuardaDigitalContext(DbContextOptions<GuardaDigitalContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=hackinrio.database.windows.net;Database=hacknit;User=hackingriodesafiofintech;Password=Fs8GVcQc5yWWW6vx");
            }
        }
    }
}
