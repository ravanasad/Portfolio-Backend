using Business.Features.SocialMedias.Commands.CreateSocialMedia;
using Business.Features.SocialMedias.Commands.DeleteSocialMedia;
using Business.Features.SocialMedias.Commands.UpdateSocialMedia;
using Business.Features.SocialMedias.Queries.GetByIdSocialMedia;
using Business.Features.SocialMedias.Queries.GetListSocialMedia;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : BaseController
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetByIdSocialMediaQuery request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetListAsync([FromQuery] GetListSocialMediaQuery request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> AddSocialMediaAsync([FromBody] CreateSocialMediaCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> PutSocialMediaAsync([FromBody] UpdateSocialMediaCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> DeleteSocialMediaAsync([FromBody] DeleteSocialMediaCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
