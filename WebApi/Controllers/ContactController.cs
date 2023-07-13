using Business.Features.Contacts.Commands.CreateContact;
using Business.Features.Contacts.Commands.DeleteContact;
using Business.Features.Contacts.Commands.UpdateContact;
using Business.Features.Contacts.Queries.GetByIdContact;
using Business.Features.Contacts.Queries.GetListContact;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : BaseController
    {
        [HttpGet("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetByIdContactQuery request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> GetListAsync([FromQuery] GetListContactQuery request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddContactAsync([FromBody] CreateContactCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> PutContactAsync([FromBody] UpdateContactCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> DeleteContactAsync([FromBody] DeleteContactCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
