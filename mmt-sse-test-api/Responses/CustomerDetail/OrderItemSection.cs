
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Mmt_sse_test_api.Responses
{
    // Section representing order items within an order
    public class OrderItemSection
    {
        public string product { get; set; }
        public int? quantity { get; set; }
        public decimal? priceEach { get; set; }
    }
}
