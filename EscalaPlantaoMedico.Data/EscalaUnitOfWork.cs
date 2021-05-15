using EscalaPlantaoMedico.Core.Repositorio;
using EscalaPlantaoMedico.Core.Repositorio.Contrato;
using EscalaPlantaoMedico.Data.Contexto;
using EscalaPlantaoMedico.Data.Repositorio;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data;
using System.Threading.Tasks;

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

        private Task<IDbConnection> OpenDbConnectionAsync()
        {
            return _contexto.OpenConnectionAsync();
        }

        private IDbContextTransaction BeginDbTransaction()
        {
            return _contexto.BeginTransaction();
        }

        //public async NotifyDataOperationAsync(DataOperation dataOperation)
        //{
        //    if (dataOperation == null)
        //        throw new ArgumentNullException(nameof(dataOperation));

        //    if (! _conne)
        //    {

        //    }
        //}
    }
}
