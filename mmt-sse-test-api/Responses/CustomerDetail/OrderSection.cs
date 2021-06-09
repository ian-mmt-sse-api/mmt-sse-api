
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmt_sse_test_api.CustomerSearch;
using Mmt_sse_test_api.Models;


namespace Mmt_sse_test_api.Responses
{
    // Section containing order data
    public class OrderSection
    {
        public string orderNumber { get; set; }
        public string orderDate { get; set; }
        public string deliveryAddress { get; set; }
        public IEnumerable<OrderItemSection> orderItems { get; set; }
        public string deliveryExpected { get; set; }


        // Constructor uses retrieved data to populate child members
        public OrderSection(Customer customer, Order order, IEnumerable<Orderitem> items, IEnumerable<Product> products)
        {
            // Populate Order section of response from passed data
            if (order != null)
            {
                orderNumber = order.Orderid.ToString();
                orderDate = order.Orderdate.HasValue ? order.Orderdate.Value.ToString("dd-MMM-yyyy") : null;
                deliveryExpected = order.Deliveryexpected.HasValue ? order.Deliveryexpected.Value.ToString("dd-MMM-yyyy") : null;
            }

            // Delivery address is a string combination of constituent address parts
            deliveryAddress = $"{(String.IsNullOrEmpty(customer.houseNumber) ? "" : customer.houseNumber + " ")}" +
                              $"{(String.IsNullOrEmpty(customer.street) ? "" : customer.street)}, " +
                              $"{(String.IsNullOrEmpty(customer.town) ? "" : customer.town + ", ")}" +
                              $"{(String.IsNullOrEmpty(customer.postcode) ? "" : customer.postcode)}";

            // Get product name from matching product, but substitute product name for "Gift" if appropriate
            orderItems = items.Select(i => new OrderItemSection() { product = (order.Containsgift.HasValue && order.Containsgift.Value
                                                                                    ? "Gift"
                                                                                    : products.FirstOrDefault(p => p.Productid == i.Productid)?.Productname),
                                                                    priceEach = i.Price,
                                                                    quantity = i.Quantity });
        }

    }
}
