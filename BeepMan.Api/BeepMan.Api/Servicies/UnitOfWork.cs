using System;
using BeepMan.Model;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace BeepMan.Api.Servicies
{
    public class UnitOfWork : IDisposable
    {
        private bool disposed = false;

        private readonly ApplicationDbContext _context;

        protected UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<bool> ExecuteTransactionAsync(Action action, CancellationToken cancellationToken)
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
                Console.WriteLine("Transaction rollback.");
                throw;
            }
            catch
            {
                throw;
            }
        }

        public Task CommitAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
