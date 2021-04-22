using EscalaPlantaoMedico.Core.Repositorio.Contrato;
using System;

namespace EscalaPlantaoMedico.Core.Repositorio
{
    public interface  IEscalaMedicaRepositorioRaiz : IDisposable
    {
        IAssistenciaRepositorio AssistenciaRepositorio { get; }

        IAtendimentoAssistenciaRepositorio AtendimentoAssistenciaRepositorio { get; }

        IEscalaRepositorio EscalaRepositorio { get; }
    }
}
