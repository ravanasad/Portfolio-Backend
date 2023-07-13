using Business.Features.Jobs.Commands.CreateJob;
using Business.Features.Jobs.Commands.DeleteJob;
using Business.Features.Jobs.Commands.UpdateJob;
using Business.Features.Jobs.Queries.GetByIdJob;
using Business.Features.Jobs.Queries.GetListJob;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : BaseController
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetByIdJobQuery request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetListAsync([FromQuery] GetListJobQuery request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> AddJobAsync([FromBody] CreateJobCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> PutJobAsync([FromBody] UpdateJobCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> DeleteJobAsync([FromBody] DeleteJobCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
