using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace OrderManagementSystem.DAL.DesignPattern

{
    public interface IUnitOfWork<T> : IDisposable where T : DbContext
    {
        #region Props

        public T OrderManagementSystemDbContext { get; }
        IDbContextTransaction DbContextTransaction { get; set; }

        public bool IsDisposed { get; }

        #endregion

        #region Methods

        bool SaveChanges();
        Task<bool> SaveChangesAsync();
        void Commit();

        #endregion
    }
}
