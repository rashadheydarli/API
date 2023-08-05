using System;
using System.Text.Json;
using Business.DTOs.Common;
using Business.Exceptions;

namespace Presentation.Middlewares
{
	public class CustomExceptionMiddleware
	{
        private readonly RequestDelegate _next;  // middleware isledikden sonra ya basqa middleware islemelidir yada action bunlari da da cagiran nextdir

        public CustomExceptionMiddleware(RequestDelegate next)
		{
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                HandleExceptionAsync(context, e);
            }
        }

        public async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            Response response = new Response();
            switch (ex)
            {
                case ValidationException e:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    response.Errors = e.Errors;
                    break;
                case NotFoundException e:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    response.Errors = e.Errors;
                    break;
                case UnauthorizedException e:
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    response.Errors = e.Errors;
                    break;
                default:
                    break;
            }
            
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
	}
}

