using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace EscalaPlantaoMedico.Data
{
    public interface IAsyncDbConnection : IDbConnection
    {
        Task<IEnumerable<dynamic>> QueryAsync(CommandDefinition command);


        Task<IEnumerable<dynamic>> QueryAsync(string sql, object parametros, IDbTransaction transaction = null);

        Task<IEnumerable<T>> QueryAsync<T>(CommandDefinition command);

        Task<IEnumerable<T>> QueryAsync<T>(string sql, object parametros, IDbTransaction transaction = null);

        Task<int> ExecuteAsync(CommandDefinition command);

        Task<int> InsertAsync<T>(T dto) where T : class;

        Task<bool> UpdateAsync<T>(T dto) where T : class;

        IDbTransaction Transaction { get; }


    }
}
