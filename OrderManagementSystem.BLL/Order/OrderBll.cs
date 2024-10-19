using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.BLL.Guide;
using OrderManagementSystem.BLL.People;
using OrderManagementSystem.Common.General;
using OrderManagementSystem.DAL.DesignPattern;
using OrderManagementSystem.DTO;
using OrderManagementSystem.DTO.Order;
using OrderManagementSystem.DTO.People;
using OrderManagementSystem.Tables.Guide;
using OrderManagementSystem.Tables.Order;
using OrderManagementSystem.Tables.People;

namespace OrderManagementSystem.BLL.Order
{
    public class OrderBll(IRepository<Tables.Order.Order> repoOrder,
                          IRepository<OrderItem> repoOrderItem,
                          IRepository<User> repoUser,
                          ProductBll productBll,
                          CustomerBll customerBll,
                          IRepository<Product> repoProduct)
    {
        public async Task<ResultDto> PlaceOrderAsync(CreateOrderDto createOrderDto)
        {
            var result = new ResultDto() { Status = false, Message = AppConstants.EnMessages.PlaceOrderFailed };
            var customerId = Guid.Empty;
            var customerExists = repoUser.GetAllAsNoTracking()
                .FirstOrDefault(u => u.Email.ToLower().Trim() == createOrderDto.CustomerInfo.Email.ToLower().Trim());
            if (customerExists == null)
            {
                //if (createOrderDto.CustomerInfo.Name.IsEmpty() ||
                //    createOrderDto.CustomerInfo.Email.IsEmpty() ||
                //    createOrderDto.CustomerInfo.DateOfBirth == null ||
                //    createOrderDto.CustomerInfo.Address.IsEmpty() ||
                //    createOrderDto.CustomerInfo.Phone.IsEmpty())
                //{
                //    result.Message = AppConstants.EnMessages.PersonalDataRequired;
                //    return result;
                //}

                var createCustomer = customerBll.CreateCustomer(new CreateCustomerDto()
                {
                    Address = createOrderDto.CustomerInfo.Address,
                    Phone = createOrderDto.CustomerInfo.Phone,
                    Name = createOrderDto.CustomerInfo.Name,
                    DateOfBirth = createOrderDto.CustomerInfo.DateOfBirth,
                    Email = createOrderDto.CustomerInfo.Email
                });
                if (!createCustomer.Status) return result;
                customerId = (Guid)createCustomer.Data;
            }
            else
            {
                customerId = customerExists.Id;
            }

            var order = new Tables.Order.Order
            {
                OrderDate = DateTime.UtcNow,
                TotalAmount = 0,
                CustomerId = customerId,
                Status = OrderStatusEnum.Pending,
                OrderItems = new List<OrderItem>()
            };

            foreach (var itemDto in createOrderDto.OrderItems)
            {
                var product = (await repoProduct.GetAllAsync()).FirstOrDefault(x => x.Id == itemDto.ProductId);
                if (product == null)
                {
                    result.Message = AppConstants.EnMessages.ProductNotFound;
                    return result;
                }

                if (itemDto.Quantity <= 0)
                {
                    result.Message = AppConstants.EnMessages.QtyMustGreateZero;
                    return result;
                }

                if (product.StockQuantity < itemDto.Quantity)
                {
                    result.Message = AppConstants.EnMessages.requiredQtyNotEnough;
                    return result;
                }

                var orderItem = new OrderItem
                {
                    ProductId = itemDto.ProductId,
                    Quantity = itemDto.Quantity,
                    UnitPrice = product.Price
                };

                product.StockQuantity = product.StockQuantity - (long)itemDto.Quantity;
                repoProduct.UpdateWithoutSaveChange(product);
                order.TotalAmount += orderItem.UnitPrice * (decimal)orderItem.Quantity;
                order.OrderItems.Add(orderItem);
            }


            if (await repoOrder.InsertAsync(order))
            {
                repoProduct.SaveChange();
                result.Status = true;
                result.Message = AppConstants.EnMessages.PlaceOrderSuccess;
                return result;
            }
            return result;
        }

        public async Task<ResultDto> GetOrdersListByOwnerId(Guid OwnerId)
        {
            var result = new ResultDto() { Status = true };

            var orders = await repoOrder.GetAllAsNoTracking()
                .Include(x => x.OrderItems)
                .ThenInclude(x => x.Product)
                .Include(x => x.Customer)
                .Where(x => !x.IsDeleted && x.OrderItems.Any(oi => oi.Product.OwnerId == OwnerId))
                .OrderByDescending(x => x.CreatedDate)
                .Select(x => new OrderListDto()
                {
                    OrderId = x.Id,
                    OrderDate = x.OrderDate,
                    OrderDateStr = x.OrderDate.ToString("yyyy-MM-dd"),
                    CustomerName = x.Customer.Name,
                    Phone = x.Customer.Phone,
                    Address = x.Customer.Address,
                    TotalAmount = x.TotalAmount,
                    Status = x.Status,
                    ChangeStatusDate = x.ChangeStatusDate == null ? "Not specified" : x.ChangeStatusDate.Value.ToString("yyyy-MM-dd"),
                    Items = x.OrderItems.Select(oi => new OrderListItemDto
                    {
                        ProductName = oi.Product.Name,
                        Quantity = oi.Quantity,
                        UnitPrice = oi.UnitPrice
                    }).ToList()
                }).ToListAsync();

            result.Data = orders;
            return result;
        }

        public async Task<ResultDto> AcceptOrder(Guid orderId)
        {
            var result = new ResultDto() { Status = false, Message = AppConstants.EnMessages.SavedFailed };
            if (orderId == Guid.Empty) return result;

            var orderData = (await repoOrder.GetAllAsync())
                .FirstOrDefault(x => x.Id == orderId);
            if (orderData == null) return result;

            orderData.Status = OrderStatusEnum.Confirmed;
            orderData.ChangeStatusDate = AppDateTime.Now;

            if (await repoOrder.UpdateAsync(orderData))
            {
                result.Status = true;
                result.Message = AppConstants.EnMessages.SavedSuccess;
                return result;
            }
            return result;
        }

        public async Task<ResultDto> CancelOrder(Guid orderId)
        {
            var result = new ResultDto() { Status = false, Message = AppConstants.EnMessages.SavedFailed };
            if (orderId == Guid.Empty) return result;

            var orderData = (await repoOrder.GetAllAsync()).Where(x => x.Id == orderId)
                .Include(x => x.OrderItems)
                .FirstOrDefault();

            if (orderData == null) return result;
            bool isQuantityRetrevied = false;
            orderData.Status = OrderStatusEnum.Canceled;
            orderData.ChangeStatusDate = AppDateTime.Now;

            foreach (var item in orderData.OrderItems)
            {
                var product = (await repoProduct.GetAllAsync()).FirstOrDefault(x => x.Id == item.ProductId);
                if (product != null)
                {
                    product.StockQuantity += (long)item.Quantity;
                    isQuantityRetrevied = repoProduct.UpdateWithoutSaveChangeWithStatus(product);
                    if (!isQuantityRetrevied)
                    {
                        repoProduct.Dispose();
                        repoOrder.Dispose();
                        return result;
                    }
                }

            }

            if (await repoOrder.UpdateAsync(orderData))
            {
                repoProduct.SaveChange();
                result.Status = true;
                result.Message = AppConstants.EnMessages.SavedSuccess;
                return result;
            }
            return result;
        }
        public async Task<ResultDto> GetOrdersListByCustomerEmail(string email)
        {
            var result = new ResultDto() { Status = true };

            var orders = await repoOrder.GetAllAsNoTracking()
                .Include(x => x.OrderItems)
                .ThenInclude(x => x.Product)
                .Where(x => !x.IsDeleted && !x.Customer.IsDeleted && x.Customer.Email == email)
                .OrderByDescending(x => x.CreatedDate)
                .Select(x => new OrderListDto()
                {
                    OrderId = x.Id,
                    OrderDate = x.OrderDate,
                    CustomerName = x.Customer.Name,
                    OrderDateStr = x.OrderDate.ToString("yyyy-MM-dd"),
                    Phone = x.Customer.Phone,
                    Address = x.Customer.Address,
                    TotalAmount = x.TotalAmount,
                    Status = x.Status,
                    ChangeStatusDate = x.ChangeStatusDate == null ? "Not specified" : x.ChangeStatusDate.Value.ToString("yyyy-MM-dd"),
                    Items = x.OrderItems.Select(oi => new OrderListItemDto
                    {
                        ProductName = oi.Product.Name,
                        Quantity = oi.Quantity,
                        UnitPrice = oi.UnitPrice
                    }).ToList()
                }).ToListAsync();

            result.Data = orders;
            return result;
        }
        public async Task<List<Tables.Order.Order>> GetAllOrdersAsync()
        {
            var orders = await repoOrder.GetAllAsync().Result
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ToListAsync();

            if (orders == null || !orders.Any())
            {
                return new List<Tables.Order.Order>();
            }

            return orders;
        }


    }
}
