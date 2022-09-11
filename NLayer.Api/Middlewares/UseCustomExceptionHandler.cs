using Microsoft.AspNetCore.Diagnostics;
using NLayer.Core.Dtos;
using NLayer.Service.Exceptions;
using System.Text.Json;

namespace NLayer.Api.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    IExceptionHandlerFeature exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                    int statusCode = exceptionHandlerFeature.Error switch
                    {
                        ClientSideException => 400,
                        _ => 500
                    };
                    context.Response.StatusCode = statusCode;

                    CustomResponseDto<NoContentDto> response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionHandlerFeature.Error.Message);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
