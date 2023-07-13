using Business.Features.Files.Commands;
using Business.Features.Files.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : BaseController
    {

        [HttpGet("[action]")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetByIdFileQuery request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetListAsync([FromQuery] GetListFileQuery request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes ="Admin")]
        public async Task<IActionResult> PostFileAsync([FromForm] UploadFileCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> DeleteFileAsync([FromForm] DeleteFileCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

    }
}
