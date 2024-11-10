using Core.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Api.Filters.ExceptionFilters
{
    public class HandleExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<HandleExceptionFilter> _logger;
        private readonly ProblemDetailsFactory _problemDetailsFactory;

        public HandleExceptionFilter(ILogger<HandleExceptionFilter> logger, ProblemDetailsFactory problemDetailsFactory)
        {
            _logger = logger;
            _problemDetailsFactory = problemDetailsFactory;
        }

        public void OnException(ExceptionContext context)
        {
            var httpContext = context.HttpContext;
            var message = context.Exception.Message;

            var result = _problemDetailsFactory.CreateProblemDetails(httpContext, 500, "Internal server error", detail: message + " " + context.Exception.InnerException.Message);

            _logger.LogWarning(message);

            if (context.Exception is NotFoundException)
            {
                result = _problemDetailsFactory
                    .CreateProblemDetails(
                    httpContext,
                    statusCode: 404,
                    detail: context.Exception.Message,
                    title: "Not Found");
            }
            else if (context.Exception is FailedSavingException)
            {
                result = _problemDetailsFactory
                    .CreateProblemDetails(
                    httpContext,
                    statusCode: 417,
                    detail: context.Exception.Message,
                    title: "Saving Failed");
            };

            context.Result = new ObjectResult(result);
            context.ExceptionHandled = true;
        }
    }
}
