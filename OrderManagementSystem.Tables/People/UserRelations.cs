using OrderManagementSystem.Tables.Guide;

namespace OrderManagementSystem.Tables.People
{
    public partial class User
    {
        #region Relations
        public virtual ICollection<Product> Products { get; set; }

        public ICollection<User> UserCreated { get; set; }
        public ICollection<User> UserModified { get; set; }
        public ICollection<User> UserDeleted { get; set; }

        public ICollection<Customer> CustomerCreated { get; set; }
        public ICollection<Customer> CustomerModified { get; set; }
        public ICollection<Customer> CustomerDeleted { get; set; }

        #region Product
        public ICollection<Product> ProductCreated { get; set; }
        public ICollection<Product> ProductModified { get; set; }
        public ICollection<Product> ProductDeleted { get; set; }
        #endregion


        #region Order
        public ICollection<Order.Order> OrderCreated { get; set; }
        public ICollection<Order.Order> OrderModified { get; set; }
        public ICollection<Order.Order> OrderDeleted { get; set; }

        public ICollection<Order.OrderItem> OrderItemCreated { get; set; }
        public ICollection<Order.OrderItem> OrderItemModified { get; set; }
        public ICollection<Order.OrderItem> OrderItemDeleted { get; set; }
        #endregion


        #endregion

    }
}
