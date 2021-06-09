
// Testing purposes only!


//using Microsoft.AspNetCore.Mvc;
//using Mmt_sse_test_api.Interfaces;
//using Mmt_sse_test_api.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;


//namespace Mmt_sse_test_api.Controllers
//{

//    [Route("api/[controller]")]
//    public class OrderItemController : Controller
//    {
//        private readonly ITestApiService _testApiService;

//        public OrderItemController(ITestApiService testApiService)
//        {
//            _testApiService = testApiService;
//        }

//        [HttpGet]
//        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Orderitem>))]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
//        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
//        public async Task<IActionResult> Get()
//        {
//            IEnumerable<Orderitem> products = await _testApiService.GetAllOrderItems();

//            if (products == null)
//                return NotFound();

//            return Ok(products);
//        }

//    }
//}
