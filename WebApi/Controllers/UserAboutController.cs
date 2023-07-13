
using Business.Features.Files.Commands;
using Business.Features.UserAbouts.Commands.CreateUserAbout;
using Business.Features.UserAbouts.Commands.DeleteUserAbout;
using Business.Features.UserAbouts.Commands.UpdateUserAbout;
using Business.Features.UserAbouts.Queries.GetByIdUserAbout;
using Business.Features.UserAbouts.Queries.GetListUserAbout;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAboutController : BaseController
    {
        //todo delete
        [HttpGet("[action]")]
        public  IActionResult adsdasddasdadasdasdadasdsad()
        {
            var name = HttpContext.User.Identity.Name;
            return Ok(name);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetByIdUserAboutQuery request)
        {
            
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetListAsync([FromQuery] GetListUserAboutQuery request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> AddUserAboutAsync([FromForm] CreateUserAboutCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> PutUserAboutAsync([FromForm] UpdateUserAboutCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> DeleteUserAboutAsync([FromBody] DeleteUserAboutCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

    }
}
