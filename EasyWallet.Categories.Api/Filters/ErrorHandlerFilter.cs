using EasyWallet.Categories.Api.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace EasyWallet.Categories.Api.Filters
{
    public class ErrorHandlerFilter : IActionFilter
    {
        private readonly ILogger<ErrorHandlerFilter> _logger;

        public ErrorHandlerFilter(ILogger<ErrorHandlerFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                _logger.LogError(
                    $"Exception: {context.Exception.Message}\n" +
                    $"Url: {context.HttpContext.Request.Path + context.HttpContext.Request.QueryString.Value}\n");

                var response = new NoDataResponse 
                { 
                    Message = "Something went wrong." 
                };

                context.Result = new ObjectResult(response)
                {
                    StatusCode = 500,
                };
                
                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context) { }
    }
}
