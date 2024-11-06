using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyRecipeBook.Communication.Response;
using MyRecipeBook.Exceptions;
using MyRecipeBook.Exceptions.ExceptionsBase;
using System;
using System.Net;

namespace MyRecipeBook.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
           if (context.Exception is MyRecipebookExceptions)
            {
                HandleProjectExcption(context);
            }
            else
            {
                ThrowUnknowException(context);
            }
        }
        private void HandleProjectExcption(ExceptionContext context) 
        {
            if (context.Exception is ErrorOnValidationExceptios) 
            {
                var exception = context.Exception as ErrorOnValidationExceptios;

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(new ResponseErrorJson(exception.ErrorMensasges));
            }

        }
        private void ThrowUnknowException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorJson(ResourceMessagensException.UNKNOW_ERROR));
        }
    }
}
