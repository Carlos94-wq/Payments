using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payments.Api.Responses;
using Payments.Core.CustomEntities;
using Payments.Core.Entities;
using Payments.Core.Error;
using Payments.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace Payments.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class authController : ControllerBase
    {

        private readonly IAuthService _authService;
        private readonly IMapper mapper;

        public authController(IAuthService authService, IMapper mapper)
        {
            this._authService = authService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserCredentials credentials)
        {
            try
            {
                var domain = this.mapper.Map<USER>(credentials);
                var session = await this._authService.login(domain);

                var apiResponse = new ApiResponse<UserSession>(session);
                return Ok(apiResponse);
            }
            catch (HttpException e)
            {
                throw new HttpException(e.StatusCode, e.Message);
            }
        }
    }
}
