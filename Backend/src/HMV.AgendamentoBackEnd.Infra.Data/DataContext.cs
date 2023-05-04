using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace HMV.AgendamentoBackEnd.Infra.Data
{
    public class DataContext : DbContext
    {
        private IDbContextTransaction _transaction;

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        #region Transactions

        public void BeginTransaction()
        {
            _transaction = Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                SaveChanges();
                _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }

        #endregion Transactions
    }
}