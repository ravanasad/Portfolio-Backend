using Business.Dtos;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;

namespace WebApi.Middlewares
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        private IConfiguration _configuration;
        public TokenMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
            var endpoint = context.GetEndpoint();
            var authorizeAttribute = endpoint?.Metadata.GetMetadata<AuthorizeAttribute>();
            if (authorizeAttribute != null && authHeader == null)
            {
                context.Request.Headers.Append("Authorization","Bearer "+context.Request.Cookies["Access-Token"]);
            }
            await _next(context);
        }
    }

}
