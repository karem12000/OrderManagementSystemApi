using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace OrderManagementSystem.DAL.DesignPattern
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : DbContext
    {
        #region Fields

        bool _IsDisposed = false;

        public UnitOfWork(T OrderManagementSystemDbContext) => this.OrderManagementSystemDbContext = OrderManagementSystemDbContext;

        #endregion

        #region Props

        public T OrderManagementSystemDbContext { get; }
        public IDbContextTransaction DbContextTransaction { get; set; }

        public bool IsDisposed { get => _IsDisposed; }

        #endregion

        #region Methods

        public virtual void Commit() => OrderManagementSystemDbContext.Database.CurrentTransaction.Commit();

        public bool SaveChanges()
        {
            try
            {
                return OrderManagementSystemDbContext.SaveChanges() >= 0;
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return false;
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return (await OrderManagementSystemDbContext.SaveChangesAsync()) > 0;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            OrderManagementSystemDbContext.Dispose();
            _IsDisposed = true;
        }
        #endregion
    }

}
