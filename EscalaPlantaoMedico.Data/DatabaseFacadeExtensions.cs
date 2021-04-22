using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Data.Common;

namespace EscalaPlantaoMedico.Data
{
    public static class DatabaseFacadeExtensions
    {
        public static DbTransaction GetDbTransaction(this DatabaseFacade database)
        {
            if (database == null)
            {
                throw new ArgumentException(nameof(database));
            }

            return (database.CurrentTransaction as IInfrastructure<DbTransaction>).Instance;
        }
    }
}
