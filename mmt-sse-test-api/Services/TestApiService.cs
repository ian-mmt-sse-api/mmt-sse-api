
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Mmt_sse_test_api.Models;
using Mmt_sse_test_api.DBContexts;
using Mmt_sse_test_api.Interfaces;
using Mmt_sse_test_api.CustomerSearch;
using Mmt_sse_test_api.Responses;


namespace Mmt_sse_test_api.Services
{
    // Main service that does the work of this API
    public class TestApiService : ITestApiService
    {
        // Services and other resources required by this class (some injected by DI in the constructor)
        private readonly IConfiguration _config;
        private readonly ITestApiDbService _testApiDbService;
        private readonly HttpClient _httpClient = new HttpClient();

        // Constructor to populate the above resources
        public TestApiService(ITestApiDbService testApiDbService, IConfiguration config)
        {
            _testApiDbService = testApiDbService;
            _config = config;
        }

        // Wrapper for GetAllProducts test method in DB service
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _testApiDbService.GetAllProducts();
        }

        // Wrapper for GetAllOrders test method in DB service
        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _testApiDbService.GetAllOrders();
        }

        // Wrapper for GetAllOrderitems test method in DB service
        public async Task<IEnumerable<Orderitem>> GetAllOrderItems()
        {
            return await _testApiDbService.GetAllOrderItems();
        }

        // Main API method - calls customer service and DB service methods to get data to return to client
        // Gets customer/product/order/order item data, by customer email and id
        public async Task<CustomerDetailResponse> GetByCustomerEmailAndId(string email, string id)
        {
            // Get customer data by email from customer service
            Customer customer = await GetCustomerDetail(email);

            // Check data returned, and security check passed id is correct
            if (customer == null || customer.customerId != id)
                return null;

            // Get latest order for this customer
            IEnumerable<Orderitem> items = new List<Orderitem>();
            Order order = await _testApiDbService.GetLastestOrderForCustomer(id);

            // Get order items for this order
            if (order != null)
                items = await _testApiDbService.GetOrderItemsForOrder(order);

            // Ideally this should only get products in above order items for performance, rather than the entire table
            // This list could be cached to improve performance too, so it isn't continually retieved for every call
            // But there isn't much data in the table, so we'll just get it all using the test method to save time
            IEnumerable<Product> products = await _testApiDbService.GetAllProducts();

            // Return the requested data in the required format
            return new CustomerDetailResponse(customer, order, items, products);
        }





        // Call customer service to get details for this customer by their email address
        private async Task<Customer> GetCustomerDetail(string email)
        {
            // Prepare criteria to be posted to the service
            StringContent content = new StringContent(JsonConvert.SerializeObject( new CustomerSearchCriteria(email) ), Encoding.UTF8, "application/json");

            // Make HTTP call to service
            HttpResponseMessage response = await _httpClient.PostAsync($"{new Uri(_config["TestApi:CustomerServiceUrl"])}", content);

            // If successful, deserialise reaponse content into a Customer object and return it
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Customer result = JsonConvert.DeserializeObject<Customer>(json);
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
