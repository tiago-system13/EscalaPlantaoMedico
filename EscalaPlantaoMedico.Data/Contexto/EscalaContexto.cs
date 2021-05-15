using EscalaPlantaoMedico.Core.Entidades;
using EscalaPlantaoMedico.Data.Mapeamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace EscalaPlantaoMedico.Data.Contexto
{
    public class EscalaContexto: CommonDbContext
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

        public virtual IDbContextTransaction BeginTransaction()
        {
            return Database.BeginTransaction();

        }

        public virtual async Task<IDbConnection> OpenConnectionAsync(CancellationToken token = default)
        {
            await Database.OpenConnectionAsync(token).ConfigureAwait(false);
            return Database.GetDbConnection();
        }

    }
}
