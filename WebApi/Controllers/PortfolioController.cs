
using Business.Features.Portfolios.Commands.CreatePortfolio;
using Business.Features.Portfolios.Commands.DeletePortfolio;
using Business.Features.Portfolios.Commands.UpdatePortfolio;
using Business.Features.Portfolios.Queries.GetByIdPortfolio;
using Business.Features.Portfolios.Queries.GetListPortfolio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : BaseController
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetByIdPortfolioQuery request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetListAsync([FromQuery] GetListPortfolioQuery request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> AddPortfolioAsync([FromForm] CreatePortfolioCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> PutPortfolioAsync([FromForm] UpdatePortfolioCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> DeletePortfolioAsync([FromBody] DeletePortfolioCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        
    }
}
