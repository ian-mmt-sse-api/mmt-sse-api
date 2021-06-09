
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmt_sse_test_api.Models;


namespace Mmt_sse_test_api.Interfaces
{
    // Interface for TestApiDBService, used by DI
    public interface ITestApiDbService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<Order>> GetAllOrders();
        Task<IEnumerable<Orderitem>> GetAllOrderItems();
        Task<Order> GetLastestOrderForCustomer(string customerId);
        Task<IEnumerable<Orderitem>> GetOrderItemsForOrder(Order order);

    }
}
