using Business.Features.Abouts.Commands.CreateAbout;
using Business.Features.Abouts.Commands.DeleteAbout;
using Business.Features.Abouts.Commands.UpdateAbout;
using Business.Features.Abouts.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : BaseController
    {
        private IHttpContextAccessor _context;

        public AboutController(IHttpContextAccessor context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetByIdAboutQuery request)
        {
            
            var response = await Mediator.Send(request);
            return Ok(response);
        }
        

        [HttpGet("[action]")]
        public async Task<IActionResult> GetListAsync([FromQuery] GetListAboutQuery request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes ="Admin")]
        public async Task<IActionResult> AddAboutAsync([FromBody] CreateAboutCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> PutAboutAsync([FromBody] UpdateAboutCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> DeleteAboutAsync([FromBody] DeleteAboutCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
