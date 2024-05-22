using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using incodityReservation.Application.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace incodityReservation.Application.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context,IErrorHandler errorHandler)
        {
            var exceptionHandler = context.Features.Get<IExceptionHandlerFeature>();
            errorHandler.GetError(exceptionHandler.Error);
            context.Response.StatusCode = errorHandler.StatusCode;
            await context.Response.WriteAsync(errorHandler.ErrorMessage);
        }
    }
}
