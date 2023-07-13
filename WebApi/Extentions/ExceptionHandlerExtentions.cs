using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace WebApi.Extentions
{
    public static class ExceptionHandlerExtentions
    {
        public static void ConfigureExceptionHandler<T>(this WebApplication application ,ILogger<T> logger)
        {
            application.UseExceptionHandler(option =>
            {
                option.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    if(context.Features.Get<IExceptionHandlerFeature>() is not null)
                    {
                        await context.Response.WriteAsync(JsonSerializer.Serialize(new
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = context.Features.Get<IExceptionHandlerFeature>().Error.Message,
                            Title = "My name is Gustavo but you can call me Gus."
                        }));
                    }

                });

            });
        }

    }
}
