using HMV.AgendamentoBackEnd.Domain.Entities;
using HMV.AgendamentoBackEnd.Infra.Data.Mappings;
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

        public DbSet<Usuario> Usuario { get; set; }

        #region Mappings

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
        }

        #endregion Mappings

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