using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Common.General
{

    public enum ActionEnum
    {
        Add = 1, Edit, Delete, Show
    }

    public enum OrderStatusEnum
    {
        Pending = 1, Confirmed = 2, Canceled = 3
    }

    public enum UserTypeEnum
    {
        [Display(Name = "مستخدم"), Description("مستخدم")]
        User = 1,
        [Display(Name = "عميل"), Description("عميل")]
        Customer = 2
    }
}
