
using Mmt_sse_test_api.CustomerSearch;
using Mmt_sse_test_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Mmt_sse_test_api.Responses
{
    // Response object returned by this API
    public class CustomerDetailResponse
    {
        // Child sections (each is responsible for its own population)
        public CustomerSection customer { get; set; }
        public OrderSection order { get; set; }

        // Constructor uses retrieved data to populate child members
        public CustomerDetailResponse(Customer customer, Order order, IEnumerable<Orderitem> items, IEnumerable<Product> products)
        {
            this.customer = new CustomerSection() { firstName = customer.firstName, lastName = customer.lastName };
            this.order = new OrderSection(customer, order, items, products);
        }
    }
}
