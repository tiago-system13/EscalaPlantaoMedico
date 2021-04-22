using EscalaPlantaoMedico.Core.Repositorio.Base;
using EscalaPlantaoMedico.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscalaPlantaoMedico.Data.Base
{
    public abstract class BaseUnitOfWork : IBaseUnitOfWork
    {
        private EscalaContexto contexto;

        public void CloseConnections()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void DisableTransactions()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void EnableTransactions()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
