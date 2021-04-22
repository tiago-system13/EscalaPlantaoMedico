using EscalaPlantaoMedico.Core.Repositorio;
using EscalaPlantaoMedico.Core.Repositorio.Contrato;
using EscalaPlantaoMedico.Data.Contexto;
using EscalaPlantaoMedico.Data.Repositorio;
using System;

namespace EscalaPlantaoMedico.Data
{
    public class EscalaUnitOfWork : IEscalaUnitOfWork
    {
        private readonly EscalaContexto _contexto;

        public EscalaUnitOfWork(EscalaContexto contexto)
        {
            _contexto = contexto ?? throw new ArgumentException(nameof(contexto));

            AssistenciaRepositorio = new AssistenciaRepositorio(_contexto);
        }

        public IAssistenciaRepositorio AssistenciaRepositorio { get; }

        public IAtendimentoAssistenciaRepositorio AtendimentoAssistenciaRepositorio { get; }

        public IEscalaRepositorio EscalaRepositorio { get; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
