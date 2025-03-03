using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductClientHub_Communication.Response;
using ProductClientHub_Exceptions.ExceptionsBase;

namespace ProductClientHub_API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is ProductClientHubException exception)
            {
                context.HttpContext.Response.StatusCode = (int)exception.GetHttpStatusCode();
                
                
                context.Result = new ObjectResult(new ResponseErrorMessageJson(exception.GetErrors()));
            }
            else
            {
                ThrowUnknowError(context);
            }
        }

        private void ThrowUnknowError(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorMessageJson("Error desconhecido"));
        }
    }

}
