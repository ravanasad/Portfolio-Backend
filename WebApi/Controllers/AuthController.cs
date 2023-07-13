using Business.Features.Auths.Commands.AssignRoleToUser;
using Business.Features.Auths.Commands.Login;
using Business.Features.Auths.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> RegisterAsync(RegisterCommand request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginCommand request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AssignRoleToUserAsync([FromBody]AssignRoleToUserCommand request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}
