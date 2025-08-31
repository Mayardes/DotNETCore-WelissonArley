using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyBookOfRecipes.Application.Exceptions;
using MyBookOfRecipes.Application.Exceptions.Base;

namespace MyBookOfRecipes.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is MyBookOfRecipesException)
                HandleApplicationException(context);
            else
                HandleUnknowException(context);
        }

        private static void HandleApplicationException(ExceptionContext context)
        {
            if(context.Exception is ValidationException)
            {
                var validation = context.Exception as ValidationException;

                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new BadRequestObjectResult(new
                {
                    validation?.ErrorMessage
                });
            }
        }

        private static void HandleUnknowException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.HttpContext.Response.WriteAsJsonAsync(new
            {
                context.Exception.Message
            });
        }
    }
}
