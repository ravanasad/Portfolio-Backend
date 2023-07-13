
using Business.Features.Blogs.Commands.CreateBlog;
using Business.Features.Blogs.Commands.DeleteBlog;
using Business.Features.Blogs.Commands.UpdateBlog;
using Business.Features.Blogs.Queries.GetByIdBlog;
using Business.Features.Blogs.Queries.GetListBlog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : BaseController
    {

        [HttpGet("[action]")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetByIdBlogQuery request)
        {
            var response =await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetListAsync([FromQuery] GetListBlogQuery request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes ="Admin")]
        public async Task<IActionResult> AddBlogAsync([FromForm] CreateBlogCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> DeleteBlogAsync([FromBody]DeleteBlogCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> PutBlogAsync([FromForm] UpdateBlogCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }
        

        
    }
}
