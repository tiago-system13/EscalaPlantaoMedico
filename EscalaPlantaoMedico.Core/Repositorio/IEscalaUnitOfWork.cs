using System;

namespace EscalaPlantaoMedico.Core.Repositorio
{
    public interface IEscalaUnitOfWork: IEscalaMedicaRepositorioRaiz, IDataOperationHandler, IDisposable
    {

        void CloseConnection();

        void EnableTransactions();

        void DisableTransactions();

        void Commit();

        void Rollback();
    }
}
