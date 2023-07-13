using Business.Features.Histories.Commands.CreateHistory;
using Business.Features.Histories.Commands.DeleteHistory;
using Business.Features.Histories.Commands.UpdateHistory;
using Business.Features.Histories.Queries.GetByIdHistory;
using Business.Features.Histories.Queries.GetListHistory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : BaseController
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetByIdHistoryQuery request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetListAsync([FromQuery] GetListHistoryQuery request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> AddHistoryAsync([FromBody] CreateHistoryCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> PutHistoryAsync([FromBody] UpdateHistoryCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> DeleteHistoryAsync([FromBody] DeleteHistoryCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
