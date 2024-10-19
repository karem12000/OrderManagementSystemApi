using OrderManagementSystem.Common.General;
using OrderManagementSystem.DTO.People;

namespace OrderManagementSystem.DTO.Order
{
    internal class OrderDto
    {
    }

    public class CreateOrderDto
    {
        public CustomerDto CustomerInfo { get; set; }
        public List<CreateOrderItemDto> OrderItems { get; set; }
    }

    public class CreateOrderItemDto
    {
        public Guid ProductId { get; set; }
        public double Quantity { get; set; }
    }

    public class OrderListDto
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderDateStr { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ChangeStatusDate { get; set; }
        public OrderStatusEnum Status { get; set; }
        public string StatusStr => Status switch
        {
            OrderStatusEnum.Canceled => "تم رفض الطلب",
            OrderStatusEnum.Pending => "في انتظار الموافقة",
            OrderStatusEnum.Confirmed => "تم قبول الطلب",
            _ => "غير محدد"
        };
        public List<OrderListItemDto> Items { get; set; }
    }

    public class OrderListItemDto
    {
        public string ProductName { get; set; }
        public double Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

}
