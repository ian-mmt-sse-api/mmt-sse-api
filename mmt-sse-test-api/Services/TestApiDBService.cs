﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mmt_sse_test_api.Models;
using Mmt_sse_test_api.DBContexts;
using Mmt_sse_test_api.Interfaces;


namespace Mmt_sse_test_api.Services
{
    // Service to query database
    public class TestApiDbService : ITestApiDbService
    {
        // Reference to DB context generated by EF
        private readonly TestApiDb _testApiDb;

        // Constructor
        public TestApiDbService(TestApiDb testApiDb)
        {
            _testApiDb = testApiDb;
        }

        // Test method to query entire products table
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _testApiDb.Products.ToListAsync();
        }

        // Test method to query entire orders table
        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _testApiDb.Orders.ToListAsync();
        }

        // Test method to query entire order items table
        public async Task<IEnumerable<Orderitem>> GetAllOrderItems()
        {
            return await _testApiDb.Orderitems.ToListAsync();
        }

        // Return latest order for a customer (or null if there are none)
        public async Task<Order> GetLastestOrderForCustomer(string customerId)
        {
            return await _testApiDb.Orders
                                   .Where(o => o.Customerid == customerId)
                                   .OrderByDescending(o => o.Orderdate)
                                   .FirstOrDefaultAsync();
        }

        // Return all order items for an order
        public async Task<IEnumerable<Orderitem>> GetOrderItemsForOrder(Order order)
        {
            return await _testApiDb.Orderitems
                                   .Where(o => o.Orderid == order.Orderid)
                                   .ToListAsync();
        }
    }
}
