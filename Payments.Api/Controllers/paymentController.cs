using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Payments.Api.Responses;
using Payments.Core.CustomEntities;
using Payments.Core.Dtos;
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
    public class paymentController : ControllerBase
    {

        private readonly IPaymentService service;
        private readonly IMapper mapper;

        public paymentController(IPaymentService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetPayment([FromQuery] PaymentQueryFilters filters)
        {
            try
            {
                var payments = await this.service.getAllPayments(filters);
                var metadata = new Metada()
                {
                    pageSize = payments.PageSize,
                    currentPage = payments.CurrentPage,
                    totalPages = payments.TotalPages,
                    totalCount = payments.TotalCount
                };
                var apiResponse = new ApiResponse<List<PaymentViewModel>>(payments) { metadata = metadata };
                 
                return Ok(apiResponse);
            }
            catch (HttpException e)
            {
                throw new HttpException(e.StatusCode, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentById(int id)
        {
            try
            {
                var payment = await this.service.getPaymnatById(id);
                var apiResponse = new ApiResponse<PAYMENT>(payment);

                return Ok(apiResponse);
            }
            catch (HttpException e)
            {
                throw new HttpException(e.StatusCode, e.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> PostPayment([FromBody] PaymentInsert payment)
        {
            try
            {
                var domain = this.mapper.Map<PAYMENT>(payment);

                var payments = await this.service.insertPaymnat(domain);
                var apiResponse = new ApiResponse<int>(payments);

                return Ok(apiResponse);
            }
            catch (HttpException e)
            {
                throw new HttpException(e.StatusCode, e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutPayment([FromBody] PaymentUpdate payment)
        {
            try
            {
                var domain = this.mapper.Map<PAYMENT>(payment);

                var paymentUpdated = await this.service.updatePaymnat(domain);
                var apiResponse = new ApiResponse<bool>(paymentUpdated);

                return Ok(apiResponse);
            }
            catch (HttpException e)
            {
                throw new HttpException(e.StatusCode, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deletePayment(int id)
        {
            try
            {
                var paymentDeleted = await this.service.deletedPaymnat(id);
                var apiResponse = new ApiResponse<bool>(paymentDeleted);

                return Ok(apiResponse);
            }
            catch (HttpException e)
            {
                throw new HttpException(e.StatusCode, e.Message);
            }
        }
    }
}
