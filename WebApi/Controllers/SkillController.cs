using Business.Features.Skills.Commands.CreateSkill;
using Business.Features.Skills.Commands.DeleteSkill;
using Business.Features.Skills.Commands.UpdateSkill;
using Business.Features.Skills.Queries.GetByIdSkill;
using Business.Features.Skills.Queries.GetListSkill;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : BaseController
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetByIdSkillQuery request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetListAsync([FromQuery] GetListSkillQuery request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> AddSkillAsync([FromBody] CreateSkillCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> PutSkillAsync([FromBody] UpdateSkillCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> DeleteSkillAsync([FromBody] DeleteSkillCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
