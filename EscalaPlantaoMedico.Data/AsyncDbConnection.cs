using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace EscalaPlantaoMedico.Data
{
    public class AsyncDbConnection: DisposableObject, IAsyncDbConnection
    {
        private IDbConnection _conn;

        public virtual IDbTransaction Transaction { get; private set; }

        public string ConnectionString 
        {
            get => _conn.ConnectionString;
            set => _conn.ConnectionString = value;
        }

        public int ConnectionTimeout => _conn.ConnectionTimeout;

        public string Database => _conn.Database;

        public ConnectionState State => _conn.State;

        public AsyncDbConnection(IDbConnection connection) : base (new IDisposable[] {  connection })
        {
            _conn = connection ?? throw new ArgumentException(nameof(connection));
        }

        public object Clone() => new AsyncDbConnection(_conn);

        public Task<IEnumerable<dynamic>> QueryAsync(CommandDefinition command) => _conn.QueryAsync(command);


        public Task<IEnumerable<dynamic>> QueryAsync(string sql, object parametros, IDbTransaction transaction = null) => _conn.QueryAsync(sql: sql, parametros, transaction);
        

        public Task<IEnumerable<T>> QueryAsync<T>(CommandDefinition command) => _conn.QueryAsync<T>(command);


        public Task<IEnumerable<T>> QueryAsync<T>(string sql, object parametros, IDbTransaction transaction = null) => _conn.QueryAsync<T>(sql, parametros, transaction);


        public Task<int> ExecuteAsync(CommandDefinition command) => _conn.ExecuteAsync(command);

        public Task<int> InsertAsync<T>(T dto) where T : class
        {
            return _conn.InsertAsync<T>(dto, Transaction);
        }

        public Task<bool> UpdateAsync<T>(T dto) where T : class
        {
            return _conn.UpdateAsync<T>(dto, Transaction);
        }

        public virtual IDbTransaction BeginTransaction() => _conn.BeginTransaction();


        public virtual IDbTransaction BeginTransaction(IsolationLevel il) => _conn.BeginTransaction(il);


        public void ChangeDatabase(string databaseName) => _conn.ChangeDatabase(databaseName);

        public void Close() => _conn.Close();


        public IDbCommand CreateCommand() => _conn.CreateCommand();


        public void Open() => _conn.Open();
        

        public override void Dispose()
        {
            base.Dispose();
            _conn = null;
        }
    }
}
