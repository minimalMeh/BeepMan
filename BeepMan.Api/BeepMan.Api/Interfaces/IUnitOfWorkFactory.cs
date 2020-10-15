using System;
using System.Threading;
using System.Threading.Tasks;

namespace BeepMan.Api.Interfaces
{
    public interface IUnitOfWorkFactory
    {
        Task<bool> ExecuteTransactionAsync(Action action, CancellationToken cancellationToken = default);

        Task<bool> CommitAsync(CancellationToken cancellationToken = default);

        bool ExecuteSqlCommand(string sql, params object[] parameters);
    }
}
