
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Mmt_sse_test_api.CustomerSearch
{
    // Represents customer data as returned from Customer Details API
    public class Customer
    {
        public string email { get; set; }
        public string customerId { get; set; }
        public bool website { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime lastLoggedIn { get; set; }
        public string houseNumber { get; set; }
        public string street { get; set; }
        public string town { get; set; }
        public string postcode { get; set; }
        public string preferredLanguage { get; set; }
    }
}
