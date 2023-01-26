using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payments.Api.Responses;
using Payments.Core.Entities;
using Payments.Core.Error;
using Payments.Core.Interfaces.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payments.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class catalogController : ControllerBase
    {
        private readonly ICatalogService service;

        public catalogController(ICatalogService service)
        {
            this.service = service;
        }

        [HttpGet] 
        [Route("supplier")]
        public async Task<IActionResult> suppler()
        {
            try
            {

                var supplier = await this.service.supplierCatalog();

                var apiResponse = new ApiResponse<IEnumerable<SUPPLIER>>(supplier);
                return Ok(apiResponse);
            }
            catch (HttpException e)
            {
                throw new HttpException(e.StatusCode, e.Message);
            }
        }

        [HttpGet]
        [Route("currency")]
        public async Task<IActionResult> cuerrency()
        {
            try
            {

                var currency = await this.service.cuerrencyCatalog();

                var apiResponse = new ApiResponse<IEnumerable<CURRENCY>>(currency);
                return Ok(apiResponse);
            }
            catch (HttpException e)
            {
                throw new HttpException(e.StatusCode, e.Message);
            }
        }
    }
}
