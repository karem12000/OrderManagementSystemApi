using OrderManagementSystem.Common.General;
using OrderManagementSystem.Tables.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementSystem.Tables.People
{
    [Table(nameof(User) + "s", Schema = AppConstants.Areas.People)]
    public partial class User : BaseEntity
    {
        [Required, StringLength(100)]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public bool IsAdmin { get; set; } = false;
        public string Salt { get; set; }
        public string FullName { get; set; }

    }
}
