using OrderManagementSystem.Common.General;
using OrderManagementSystem.Tables.Base;
using OrderManagementSystem.Tables.Guide;
using OrderManagementSystem.Tables.People;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementSystem.Tables.Order
{
    [Table(nameof(Order) + "s", Schema = AppConstants.Areas.Order)]
    public class Order : BaseEntity
    {
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }



        [ForeignKey(nameof(Customer))]
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        public OrderStatusEnum Status { get; set; }
        public DateTime? ChangeStatusDate { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }


    [Table(nameof(OrderItem) + "s", Schema = AppConstants.Areas.Order)]
    public class OrderItem : BaseEntity
    {
        [Required]
        public double Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }

        [ForeignKey(nameof(Order))]
        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
