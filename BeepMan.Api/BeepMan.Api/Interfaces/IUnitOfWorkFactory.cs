using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BeepMan.Api.Interfaces
{
    public interface IUnitOfWorkFactory : IDisposable
    {
        Task<bool> ExecuteTransactionAsync(Action action, CancellationToken cancellationToken = default);

        Task<bool> CommitAsync(CancellationToken cancellationToken = default);

        bool ExecuteSqlCommand(string sql, params object[] parameters);
    }
}
