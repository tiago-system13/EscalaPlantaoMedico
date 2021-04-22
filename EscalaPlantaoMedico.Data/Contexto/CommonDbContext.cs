using Microsoft.EntityFrameworkCore;

namespace EscalaPlantaoMedico.Data.Contexto
{
    public class CommonDbContext: DbContext
    {
        public bool IsDisposed { get; private set; }

        public CommonDbContext(): base()
        {
            IsDisposed = false;
        }

        public CommonDbContext(DbContextOptions options) : base(options)
        {
            IsDisposed = false;
        }

        public override void Dispose()
        {
            base.Dispose();
            IsDisposed = true;
        }
    }
}
