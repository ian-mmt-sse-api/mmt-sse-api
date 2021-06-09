
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Mmt_sse_test_api.CustomerSearch
{
    interface ICustomer
    {
        string email { get; set; }
        string customerId { get; set; }
        bool website { get; set; }
        string firstName { get; set; }
        string lastName { get; set; }
        DateTime lastLoggedIn { get; set; }
        string houseNumber { get; set; }
        string street { get; set; }
        string town { get; set; }
        string postcode { get; set; }
        string preferredLanguage { get; set; }
    }
}
