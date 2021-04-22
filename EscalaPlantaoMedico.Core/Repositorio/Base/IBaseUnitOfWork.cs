using System;

namespace EscalaPlantaoMedico.Core.Repositorio.Base
{
    public interface IBaseUnitOfWork : IDisposable
    {
        void CloseConnections();

        void EnableTransactions();

        void DisableTransactions();

        void Commit();

        void Rollback();
    }
}
