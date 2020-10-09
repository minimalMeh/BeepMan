using System;
using BeepMan.Model;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using BeepMan.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BeepMan.Api.Servicies
{
    public class UnitOfWork : IUnitOfWorkFactory
    {
        private bool disposed = false;

        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<bool> ExecuteTransactionAsync(Action action, CancellationToken cancellationToken = default)
        {
            try
            {
                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required,
                    new TransactionOptions() { IsolationLevel = IsolationLevel.Serializable }))
                {
                    action();
                    await this.CommitAsync(cancellationToken);
                    transactionScope.Complete();
                    return true;
                }
            }
            catch (TransactionAbortedException e)
            {
                Console.WriteLine("Transaction rollback. " + e.Message);
                throw;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> CommitAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public bool ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return this._context.Database.ExecuteSqlRaw(sql, parameters) > 0;
        }
    }
}
