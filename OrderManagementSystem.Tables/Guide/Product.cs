using OrderManagementSystem.Common.General;
using OrderManagementSystem.Tables.Base;
using OrderManagementSystem.Tables.Order;
using OrderManagementSystem.Tables.People;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementSystem.Tables.Guide
{
    [Table(nameof(Product) + "s", Schema = AppConstants.Areas.Guide)]
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public long StockQuantity { get; set; }

        [ForeignKey(nameof(User))]
        public Guid OwnerId { get; set; }
        public User User { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
