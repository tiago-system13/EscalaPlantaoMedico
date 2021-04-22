using EscalaPlantaoMedico.Core.Entidades;
using EscalaPlantaoMedico.Data.Mapeamento;
using Microsoft.EntityFrameworkCore;

namespace EscalaPlantaoMedico.Data.Contexto
{
    public class EscalaContexto: DbContext
    {
        public DbSet<Escala> Escalas { get; set; }

        public DbSet<Assistencia> Assistencias { get; set; }

        public DbSet<AtendimentoAssistencial> AtendimentoAssistencials { get; set; }

        public EscalaContexto(DbContextOptions<EscalaContexto> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EscalaMapeamento());
            modelBuilder.ApplyConfiguration(new AssistenciaMapeamento());
            modelBuilder.ApplyConfiguration(new AtendimentoAssistencialMapeamento());

        }
    }
}
