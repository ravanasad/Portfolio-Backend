using Business.Features.Roles.Command;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes ="Admin")]
    public class RoleController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateRoleAsync(CreateRoleCommand request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateRoleAsync(UpdateRoleCommand request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteRoleAsync(DeleteRoleCommand request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}
