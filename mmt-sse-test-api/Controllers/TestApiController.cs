
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mmt_sse_test_api.Interfaces;
using Mmt_sse_test_api.Responses;


namespace Mmt_sse_test_api.Controllers
{

    [Route("api/[controller]")]
    public class TestApiController : Controller
    {
        private readonly ITestApiService _testApiService;

        // Constructor with injected service
        public TestApiController(ITestApiService testApiService)
        {
            _testApiService = testApiService;
        }

        // Controller method to look up required data for passed customer email and id
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDetailResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByCustomerDetails(string email, string id)
        {
            try
            {
                // Call service method to look up data
                CustomerDetailResponse response = await _testApiService.GetByCustomerEmailAndId(email, id);

                // Handle case when no data found (or passed id is incorrect)
                if (response == null)
                    return NotFound();

                // return OK response with requested data
                return Ok(response);
            }
            catch (Exception ex)
            {
                // log exception
                // here we just rethrow caught exception for dev purposes, should be wrapped so doesn't throw in production environment
                throw;
            }
        }

    }
}
