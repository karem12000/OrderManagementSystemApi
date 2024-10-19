using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Tables.Guide;
using OrderManagementSystem.Tables.Order;
using OrderManagementSystem.Tables.People;

namespace OrderManagementSystem.DAL
{
    public class OrderManagementSystemContext(DbContextOptions<OrderManagementSystemContext> options)
        : DbContext(options)
    {
        #region Overrides

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            #region People
            modelBuilder.Entity<User>().HasMany(x => x.UserCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.UserModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.UserDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);


            modelBuilder.Entity<User>().HasMany(x => x.CustomerCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.CustomerModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.CustomerDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);

            #endregion

            #region Guide
            modelBuilder.Entity<User>().HasMany(x => x.ProductCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.ProductModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.ProductDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);

            #endregion
            #region Order
            modelBuilder.Entity<User>().HasMany(x => x.OrderCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.OrderModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.OrderDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);

            modelBuilder.Entity<User>().HasMany(x => x.OrderItemCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.OrderItemModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.OrderItemDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);


            #endregion

        }

        #endregion
        #region Entities

        #region People
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }

        #endregion



        #region Guide
        public DbSet<Product> Products { get; set; }
        #endregion

        #region Order
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        #endregion

        #endregion
    }
}
