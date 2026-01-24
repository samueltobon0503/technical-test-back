using CleanArch.Application.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Application.Exceptions
{
    public class ExceptionManager : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            int statusCode = StatusCodes.Status500InternalServerError;
            string message = context.Exception.Message;

            if (context.Exception is DbUpdateConcurrencyException)
            {
                statusCode = StatusCodes.Status409Conflict;
            }

            context.Result = new ObjectResult(ResponseApiService.Response(statusCode, null, message));
            context.HttpContext.Response.StatusCode = statusCode;

            context.ExceptionHandled = true;
        }
    }
}
