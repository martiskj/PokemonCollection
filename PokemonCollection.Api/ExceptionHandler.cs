using Microsoft.AspNetCore.Mvc;
using PokemonCollection.Application;

namespace PokemonCollection.Api;

internal static class ExceptionHandler
{
    internal static void UseCustomExceptionHandler(this WebApplication app)
    {
        app.Use(async (context, next) =>
        {
            try
            {
                await next(context);
            }
            catch (ResourceNotFoundException e)
            {
                await SetResponse(context, e, 404);
            }
            catch (ArgumentException e)
            {
                await SetResponse(context, e, 400);
            }
        });
    }

    private static async Task SetResponse(HttpContext context, Exception e, int statusCode)
    {
        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Title = e.GetType().Name,
            Detail = e.Message,
            Status = context.Response.StatusCode,
        });
    }
}
