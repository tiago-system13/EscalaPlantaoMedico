using EscalaPlantaoMedico.Core.Enum;
using EscalaPlantaoMedico.Core.Repositorio;
using EscalaPlantaoMedico.Core.Repositorio.Contrato;
using EscalaPlantaoMedico.Data.Contexto;
using EscalaPlantaoMedico.Data.Repositorio;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace EscalaPlantaoMedico.Data
{
    public class EscalaUnitOfWork : IEscalaUnitOfWork
    {
        private EscalaContexto _contexto;

        private Dictionary<DataSource, IDbConnection> _connections;

        private Dictionary<DataSource, IDbContextTransaction> _transactions;

        private IAssistenciaRepositorio _assistenciaRepositorio;

        private IAtendimentoAssistenciaRepositorio _atendimentoAssistenciaRepositorio;

        private IEscalaRepositorio _escalaRepositorio;

        public bool ActiveTransaction { get; private set; }



        private bool _disposedValue = false;

        public EscalaUnitOfWork(EscalaContexto contexto)
        {
            _contexto = contexto ?? throw new ArgumentException(nameof(contexto));

            _connections = new Dictionary<DataSource, IDbConnection>();
            _transactions = new Dictionary<DataSource, IDbContextTransaction>();

            ActiveTransaction = false;
        }

        public IAssistenciaRepositorio AssistenciaRepositorio
        {
            get
            {
                if (_assistenciaRepositorio == null)
                {
                    new AssistenciaRepositorio(_contexto);
                }

                return _assistenciaRepositorio;
                
            }

        }

        public IAtendimentoAssistenciaRepositorio AtendimentoAssistenciaRepositorio
        {
            get {

                if(_atendimentoAssistenciaRepositorio == null)
                
                 new AtendimentoAssistenciaRepositorio(_contexto);

                return _atendimentoAssistenciaRepositorio;
            }

        }
        public IEscalaRepositorio EscalaRepositorio
        {
            get
            {
                if(_escalaRepositorio == null)
                new EscalaRepositorio(_contexto);

                return _escalaRepositorio;
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if(!_disposedValue)
            {
                CloseConnection();

                if (disposing)
                {
                    _contexto?.Dispose();
                    _contexto = null;

                    AssistenciaRepositorio?.Dispose();
                    _assistenciaRepositorio = null;

                    AtendimentoAssistenciaRepositorio?.Dispose();
                    _atendimentoAssistenciaRepositorio = null;

                    EscalaRepositorio?.Dispose();
                    _escalaRepositorio = null;

                }
            }         
        }

        private Task<IDbConnection> OpenDbConnectionAsync(DataSource source)
        {
            switch (source)
            {
                case DataSource.EscalaMedica:
                    return _contexto.OpenConnectionAsync();
                default:
                    throw new NotSupportedException($"OpenDbConnectionAsync not implemented for {source}");
            }
            
        }

        private IDbContextTransaction BeginDbTransaction(DataSource source)
        {
            switch (source)
            {
                case DataSource.EscalaMedica:
                    return _contexto.BeginTransaction();
                default:
                    throw new NotSupportedException($"BeginTransactionAsync not implemented for {source}");
            }
          
        }

        public async Task NotifyDataOperationAsync(DataOperation dataOperation)
        {
            if (dataOperation == null)
                throw new ArgumentNullException(nameof(dataOperation));

            if (!_connections.ContainsKey(dataOperation.Source))
            {
                _connections.Add(dataOperation.Source, await OpenDbConnectionAsync(dataOperation.Source).ConfigureAwait(false));
            }

            if (ActiveTransaction && dataOperation.Type == OperationType.Write &&
               !_transactions.ContainsKey(dataOperation.Source))
                _transactions.Add(dataOperation.Source, BeginDbTransaction(dataOperation.Source));
        }

        public void EnableTransactions()
        {
            ActiveTransaction = true;
        }

        public void DisableTransactions()
        {
            ActiveTransaction = false;

            Rollback();

        }

        public void Commit()
        {
            foreach (var kvp in _transactions)
            {
                kvp.Value.Commit();
            }

            _transactions.Clear();
        }

        public void Rollback()
        {
            foreach (var kvp in _transactions)
            {
                kvp.Value.Rollback();
            }

            _transactions.Clear();
        }

        public void CloseConnection()
        {
            Rollback();

            foreach (var kvp in _connections)
            {
                kvp.Value.Close();
            }

            _connections.Clear();
        }

        public void Dipose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task NotifyDataOperation(DataOperation dataOperation)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        EscalaUnitOfWork()
        {
            Dispose(false);
        }


    }
}
