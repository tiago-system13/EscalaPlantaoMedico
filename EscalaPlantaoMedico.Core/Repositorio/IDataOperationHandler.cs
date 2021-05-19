using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EscalaPlantaoMedico.Core.Repositorio
{
    public interface IDataOperationHandler
    {
        Task NotifyDataOperation(DataOperation dataOperation);
    }
}
