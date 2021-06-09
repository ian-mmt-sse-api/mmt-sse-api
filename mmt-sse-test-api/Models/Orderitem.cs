﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Mmt_sse_test_api.Models
{
    public partial class Orderitem
    {
        public int Orderitemid { get; set; }
        public int? Orderid { get; set; }
        public int? Productid { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public bool? Returnable { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}