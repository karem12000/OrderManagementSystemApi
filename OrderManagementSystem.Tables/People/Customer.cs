using OrderManagementSystem.Common.General;
using OrderManagementSystem.Tables.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementSystem.Tables.People
{
    [Table(nameof(Customer) + "s", Schema = AppConstants.Areas.People)]
    public class Customer : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Order.Order> Orders { get; set; }
    }
}
