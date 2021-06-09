
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Mmt_sse_test_api.CustomerSearch
{
    // Represents criteria passed to Customer Details API
    public class CustomerSearchCriteria : ICustomerSearchCriteria
    {
        public string email { get; set; }

        public CustomerSearchCriteria(string customerEmail)
        {
            email = customerEmail;
        }
    }
}
