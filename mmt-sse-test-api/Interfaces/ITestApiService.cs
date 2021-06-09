
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmt_sse_test_api.Models;
using Mmt_sse_test_api.Responses;

namespace Mmt_sse_test_api.Interfaces
{
    // Interface for TestApiService, used by DI
    public interface ITestApiService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<Order>> GetAllOrders();
        Task<IEnumerable<Orderitem>> GetAllOrderItems();
        Task<CustomerDetailResponse> GetByCustomerEmailAndId(string email, string id);
    }
}
